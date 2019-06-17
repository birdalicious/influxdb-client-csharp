using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InfluxDB.Client.Api.Domain;
using InfluxDB.Client.Api.Service;
using InfluxDB.Client.Core;
using InfluxDB.Client.Domain;
using Task = System.Threading.Tasks.Task;

namespace InfluxDB.Client
{
    public class OrganizationsApi
    {
        private readonly OrganizationsService _service;

        protected internal OrganizationsApi(OrganizationsService service)
        {
            Arguments.CheckNotNull(service, nameof(service));

            _service = service;
        }

        /// <summary>
        /// Creates a new organization and sets <see cref="InfluxDB.Client.Api.Domain.Organization.Id" /> with the new identifier.
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Created organization</returns>
        public async Task<Organization> CreateOrganization(string name)
        {
            Arguments.CheckNonEmptyString(name, nameof(name));

            var organization = new Organization(null, name);

            return await CreateOrganization(organization);
        }

        /// <summary>
        /// Creates a new organization and sets <see cref="Organization.Id" /> with the new identifier.
        /// </summary>
        /// <param name="organization">the organization to create</param>
        /// <returns>created organization</returns>
        public async Task<Organization> CreateOrganization(Organization organization)
        {
            Arguments.CheckNotNull(organization, nameof(organization));

            return await _service.PostOrgsAsync(organization);
        }

        /// <summary>
        /// Update an organization.
        /// </summary>
        /// <param name="organization">organization update to apply</param>
        /// <returns>updated organization</returns>
        public async Task<Organization> UpdateOrganization(Organization organization)
        {
            Arguments.CheckNotNull(organization, nameof(organization));

            return await _service.PatchOrgsIDAsync(organization.Id, organization);
        }

        /// <summary>
        /// Delete an organization.
        /// </summary>
        /// <param name="orgId">ID of organization to delete</param>
        /// <returns>delete has been accepted</returns>
        public async Task DeleteOrganization(string orgId)
        {
            Arguments.CheckNotNull(orgId, nameof(orgId));

            await _service.DeleteOrgsIDAsync(orgId);
        }

        /// <summary>
        /// Delete an organization.
        /// </summary>
        /// <param name="organization">organization to delete</param>
        /// <returns>delete has been accepted</returns>
        public async Task DeleteOrganization(Organization organization)
        {
            Arguments.CheckNotNull(organization, nameof(organization));

            await DeleteOrganization(organization.Id);
        }

        /// <summary>
        /// Clone an organization.
        /// </summary>
        /// <param name="clonedName">name of cloned organization</param>
        /// <param name="bucketId">ID of organization to clone</param>
        /// <returns>cloned organization</returns>
        public async Task<Organization> CloneOrganization(string clonedName, string bucketId)
        {
            Arguments.CheckNonEmptyString(clonedName, nameof(clonedName));
            Arguments.CheckNonEmptyString(bucketId, nameof(bucketId));

            return await FindOrganizationById(bucketId).ContinueWith(t => CloneOrganization(clonedName, t.Result)).Unwrap();
        }

        /// <summary>
        /// Clone an organization.
        /// </summary>
        /// <param name="clonedName">name of cloned organization</param>
        /// <param name="organization">organization to clone</param>
        /// <returns>cloned organization</returns>
        public async Task<Organization> CloneOrganization(string clonedName, Organization organization)
        {
            Arguments.CheckNonEmptyString(clonedName, nameof(clonedName));
            Arguments.CheckNotNull(organization, nameof(organization));

            var cloned = new Organization(null, clonedName);

            return await CreateOrganization(cloned).ContinueWith(created =>
            {
                //
                // Add labels
                //
                return GetLabels(organization)
                    .ContinueWith(labels => { return labels.Result.Select(label => AddLabel(label, created.Result)); })
                    .ContinueWith(async tasks =>
                    {
                        await Task.WhenAll(tasks.Result);
                        return created.Result;
                    })
                    .Unwrap();
            }).Unwrap();
        }

        /// <summary>
        /// Retrieve an organization.
        /// </summary>
        /// <param name="orgId">ID of organization to get</param>
        /// <returns>organization details</returns>
        public async Task<Organization> FindOrganizationById(string orgId)
        {
            Arguments.CheckNonEmptyString(orgId, nameof(orgId));

            return await _service.GetOrgsIDAsync(orgId);
        }

        /// <summary>
        /// List all organizations.
        /// </summary>
        /// <returns>List all organizations</returns>
        public async Task<List<Organization>> FindOrganizations()
        {
            return await _service.GetOrgsAsync().ContinueWith(t => t.Result.Orgs);
        }

        /// <summary>
        /// List of secret keys the are stored for Organization. For example:
        /// <code>
        /// github_api_key,
        /// some_other_key,
        /// a_secret_key
        /// </code>
        /// </summary>
        /// <param name="organization">the organization for get secrets</param>
        /// <returns>the secret keys</returns>
        public async Task<List<string>> GetSecrets(Organization organization)
        {
            Arguments.CheckNotNull(organization, nameof(organization));

            return await GetSecrets(organization.Id);
        }

        /// <summary>
        /// List of secret keys the are stored for Organization. For example:
        /// <code>
        /// github_api_key,
        /// some_other_key,
        /// a_secret_key
        /// </code>
        /// </summary>
        /// <param name="orgId">the organization for get secrets</param>
        /// <returns>the secret keys</returns>
        public async Task<List<string>> GetSecrets(string orgId)
        {
            Arguments.CheckNonEmptyString(orgId, nameof(orgId));

            return await _service.GetOrgsIDSecretsAsync(orgId).ContinueWith(t => t.Result.Secrets);
        }

        /// <summary>
        /// Patches all provided secrets and updates any previous values.
        /// </summary>
        /// <param name="secrets">secrets to update/add</param>
        /// <param name="organization">the organization for put secrets</param>
        /// <returns></returns>
        public async Task PutSecrets(Dictionary<string, string> secrets, Organization organization)
        {
            Arguments.CheckNotNull(secrets, nameof(secrets));
            Arguments.CheckNotNull(organization, nameof(organization));

            await PutSecrets(secrets, organization.Id);
        }

        /// <summary>
        /// Patches all provided secrets and updates any previous values.
        /// </summary>
        /// <param name="secrets">secrets to update/add</param>
        /// <param name="orgId">the organization for put secrets</param>
        /// <returns></returns>
        public async Task PutSecrets(Dictionary<string, string> secrets, string orgId)
        {
            Arguments.CheckNotNull(secrets, nameof(secrets));
            Arguments.CheckNonEmptyString(orgId, nameof(orgId));

            await _service.PatchOrgsIDSecretsAsync(orgId, secrets);
        }

        /// <summary>
        /// Delete provided secrets.
        /// </summary>
        /// <param name="secrets">secrets to delete</param>
        /// <param name="organization">the organization for delete secrets</param>
        /// <returns>keys successfully patched</returns>
        public async Task DeleteSecrets(List<string> secrets, Organization organization)
        {
            Arguments.CheckNotNull(secrets, nameof(secrets));
            Arguments.CheckNotNull(organization, nameof(organization));

            await DeleteSecrets(secrets, organization.Id);
        }

        /// <summary>
        /// Delete provided secrets.
        /// </summary>
        /// <param name="secrets">secrets to delete</param>
        /// <param name="orgId">the organization for delete secrets</param>
        /// <returns>keys successfully patched</returns>
        public async Task DeleteSecrets(List<string> secrets, string orgId)
        {
            Arguments.CheckNotNull(secrets, nameof(secrets));
            Arguments.CheckNonEmptyString(orgId, nameof(orgId));

            await DeleteSecrets(new SecretKeys(secrets), orgId);
        }
        
        /// <summary>
        /// Delete provided secrets.
        /// </summary>
        /// <param name="secrets">secrets to delete</param>
        /// <param name="orgId">the organization for delete secrets</param>
        /// <returns>keys successfully patched</returns>
        public async Task DeleteSecrets(SecretKeys secrets, string orgId)
        {
            Arguments.CheckNotNull(secrets, nameof(secrets));
            Arguments.CheckNonEmptyString(orgId, nameof(orgId));

            await _service.PostOrgsIDSecretsAsync(orgId, secrets);
        }

        /// <summary>
        /// List all members of an organization.
        /// </summary>
        /// <param name="organization">organization of the members</param>
        /// <returns>the List all members of an organization</returns>
        public async Task<List<ResourceMember>> GetMembers(Organization organization)
        {
            Arguments.CheckNotNull(organization, nameof(organization));

            return await GetMembers(organization.Id);
        }

        /// <summary>
        /// List all members of an organization.
        /// </summary>
        /// <param name="orgId">ID of organization to get members</param>
        /// <returns>the List all members of an organization</returns>
        public async Task<List<ResourceMember>> GetMembers(string orgId)
        {
            Arguments.CheckNonEmptyString(orgId, nameof(orgId));

            return await _service.GetOrgsIDMembersAsync(orgId).ContinueWith(t => t.Result.Users);
        }

        /// <summary>
        /// Add organization member.
        /// </summary>
        /// <param name="member">the member of an organization</param>
        /// <param name="organization">the organization of a member</param>
        /// <returns>created mapping</returns>
        public async Task<ResourceMember> AddMember(User member, Organization organization)
        {
            Arguments.CheckNotNull(organization, nameof(organization));
            Arguments.CheckNotNull(member, nameof(member));

            return await AddMember(member.Id, organization.Id);
        }

        /// <summary>
        /// Add organization member.
        /// </summary>
        /// <param name="memberId">the ID of a member</param>
        /// <param name="orgId">the ID of an organization</param>
        /// <returns>created mapping</returns>
        public async Task<ResourceMember> AddMember(string memberId, string orgId)
        {
            Arguments.CheckNonEmptyString(orgId, nameof(orgId));
            Arguments.CheckNonEmptyString(memberId, nameof(memberId));

            return await _service.PostOrgsIDMembersAsync(orgId, new AddResourceMemberRequestBody(memberId));
        }

        /// <summary>
        /// Removes a member from an organization.
        /// </summary>
        /// <param name="member">the member of an organization</param>
        /// <param name="organization">the organization of a member</param>
        /// <returns></returns>
        public async Task DeleteMember(User member, Organization organization)
        {
            Arguments.CheckNotNull(organization, nameof(organization));
            Arguments.CheckNotNull(member, nameof(member));

            await DeleteMember(member.Id, organization.Id);
        }

        /// <summary>
        /// Removes a member from an organization.
        /// </summary>
        /// <param name="memberId">the ID of a member</param>
        /// <param name="orgId">the ID of an organization</param>
        /// <returns></returns>
        public async Task DeleteMember(string memberId, string orgId)
        {
            Arguments.CheckNonEmptyString(orgId, nameof(orgId));
            Arguments.CheckNonEmptyString(memberId, nameof(memberId));

            await _service.DeleteOrgsIDMembersIDAsync(memberId, orgId);
        }

        /// <summary>
        /// List all owners of an organization.
        /// </summary>
        /// <param name="organization">organization of the owners</param>
        /// <returns>the List all owners of an organization</returns>
        public async Task<List<ResourceOwner>> GetOwners(Organization organization)
        {
            Arguments.CheckNotNull(organization, nameof(organization));

            return await GetOwners(organization.Id);
        }

        /// <summary>
        /// List all owners of an organization.
        /// </summary>
        /// <param name="orgId">ID of organization to get owners</param>
        /// <returns>the List all owners of an organization</returns>
        public async Task<List<ResourceOwner>> GetOwners(string orgId)
        {
            Arguments.CheckNonEmptyString(orgId, nameof(orgId));

            return await _service.GetOrgsIDOwnersAsync(orgId).ContinueWith(t => t.Result.Users);
        }

        /// <summary>
        /// Add organization owner.
        /// </summary>
        /// <param name="owner">the owner of an organization</param>
        /// <param name="organization">the organization of a owner</param>
        /// <returns>created mapping</returns>
        public async Task<ResourceOwner> AddOwner(User owner, Organization organization)
        {
            Arguments.CheckNotNull(organization, nameof(organization));
            Arguments.CheckNotNull(owner, nameof(owner));

            return await AddOwner(owner.Id, organization.Id);
        }

        /// <summary>
        /// Add organization owner.
        /// </summary>
        /// <param name="ownerId">the ID of a owner</param>
        /// <param name="orgId">the ID of an organization</param>
        /// <returns>created mapping</returns>
        public async Task<ResourceOwner> AddOwner(string ownerId, string orgId)
        {
            Arguments.CheckNonEmptyString(orgId, nameof(orgId));
            Arguments.CheckNonEmptyString(ownerId, nameof(ownerId));

            return await _service.PostOrgsIDOwnersAsync(orgId, new AddResourceMemberRequestBody(ownerId));
        }

        /// <summary>
        /// Removes a owner from an organization.
        /// </summary>
        /// <param name="owner">the owner of an organization</param>
        /// <param name="organization">the organization of a owner</param>
        /// <returns></returns>
        public async Task DeleteOwner(User owner, Organization organization)
        {
            Arguments.CheckNotNull(organization, nameof(organization));
            Arguments.CheckNotNull(owner, nameof(owner));

            await DeleteOwner(owner.Id, organization.Id);
        }

        /// <summary>
        /// Removes a owner from an organization.
        /// </summary>
        /// <param name="ownerId">the ID of a owner</param>
        /// <param name="orgId">the ID of an organization</param>
        /// <returns></returns>
        public async Task DeleteOwner(string ownerId, string orgId)
        {
            Arguments.CheckNonEmptyString(orgId, nameof(orgId));
            Arguments.CheckNonEmptyString(ownerId, nameof(ownerId));

            await _service.DeleteOrgsIDOwnersIDAsync(ownerId, orgId);
        }

        /// <summary>
        /// Retrieve an organization's logs
        /// </summary>
        /// <param name="organization">for retrieve logs</param>
        /// <returns>logs</returns>
        public async Task<List<OperationLog>> FindOrganizationLogs(Organization organization)
        {
            Arguments.CheckNotNull(organization, nameof(organization));

            return await FindOrganizationLogs(organization.Id);
        }

        /// <summary>
        /// Retrieve an organization's logs
        /// </summary>
        /// <param name="organization">for retrieve logs</param>
        /// <param name="findOptions">the find options</param>
        /// <returns>logs</returns>
        public async Task<OperationLogs> FindOrganizationLogs(Organization organization, FindOptions findOptions)
        {
            Arguments.CheckNotNull(organization, nameof(organization));
            Arguments.CheckNotNull(findOptions, nameof(findOptions));

            return await FindOrganizationLogs(organization.Id, findOptions);
        }

        /// <summary>
        /// Retrieve an organization's logs
        /// </summary>
        /// <param name="orgId">the ID of an organization</param>
        /// <returns>logs</returns>
        public async Task<List<OperationLog>> FindOrganizationLogs(string orgId)
        {
            Arguments.CheckNonEmptyString(orgId, nameof(orgId));

            return await FindOrganizationLogs(orgId, new FindOptions()).ContinueWith(t => t.Result.Logs);
        }

        /// <summary>
        /// Retrieve an organization's logs
        /// </summary>
        /// <param name="orgId">the ID of an organization</param>
        /// <param name="findOptions">the find options</param>
        /// <returns>logs</returns>
        public async Task<OperationLogs> FindOrganizationLogs(string orgId, FindOptions findOptions)
        {
            Arguments.CheckNonEmptyString(orgId, nameof(orgId));
            Arguments.CheckNotNull(findOptions, nameof(findOptions));

            return await _service.GetOrgsIDLogsAsync(orgId, null, findOptions.Offset, findOptions.Limit);
        }

        /// <summary>
        /// List all labels of an organization.
        /// </summary>
        /// <param name="organization">organization of the labels</param>
        /// <returns>the List all labels of an organization</returns>
        public async Task<List<Label>> GetLabels(Organization organization)
        {
            Arguments.CheckNotNull(organization, nameof(organization));

            return await GetLabels(organization.Id);
        }

        /// <summary>
        /// List all labels of an organization.
        /// </summary>
        /// <param name="orgId">ID of an organization to get labels</param>
        /// <returns>the List all labels of an organization</returns>
        public async Task<List<Label>> GetLabels(string orgId)
        {
            Arguments.CheckNonEmptyString(orgId, nameof(orgId));

            return await _service.GetOrgsIDLabelsAsync(orgId).ContinueWith(t => t.Result.Labels);
        }

        /// <summary>
        /// Add an organization label.
        /// </summary>
        /// <param name="label">the label of an organization</param>
        /// <param name="organization">an organization of a label</param>
        /// <returns>added label</returns>
        public async Task<Label> AddLabel(Label label, Organization organization)
        {
            Arguments.CheckNotNull(organization, nameof(organization));
            Arguments.CheckNotNull(label, nameof(label));

            return await AddLabel(label.Id, organization.Id);
        }

        /// <summary>
        /// Add an organization label.
        /// </summary>
        /// <param name="labelId">the ID of a label</param>
        /// <param name="orgId">the ID of an organization</param>
        /// <returns>added label</returns>
        public async Task<Label> AddLabel(string labelId, string orgId)
        {
            Arguments.CheckNonEmptyString(orgId, nameof(orgId));
            Arguments.CheckNonEmptyString(labelId, nameof(labelId));

            var mapping = new LabelMapping(labelId);
            
            return await _service.PostOrgsIDLabelsAsync(orgId, mapping).ContinueWith(t => t.Result.Label);
        }

        /// <summary>
        /// Removes a label from an organization.
        /// </summary>
        /// <param name="label">the label of an organization</param>
        /// <param name="organization">an organization of a owner</param>
        /// <returns>delete has been accepted</returns>
        public async Task DeleteLabel(Label label, Organization organization)
        {
            Arguments.CheckNotNull(organization, nameof(organization));
            Arguments.CheckNotNull(label, nameof(label));

            await DeleteLabel(label.Id, organization.Id);
        }

        /// <summary>
        /// Removes a label from an organization.
        /// </summary>
        /// <param name="labelId">the ID of a label</param>
        /// <param name="orgId">the ID of an organization</param>
        /// <returns>delete has been accepted</returns>
        public async Task DeleteLabel(string labelId, string orgId)
        {
            Arguments.CheckNonEmptyString(orgId, nameof(orgId));
            Arguments.CheckNonEmptyString(labelId, nameof(labelId));

            await _service.DeleteOrgsIDLabelsIDAsync(orgId, labelId);
        }
    }
}