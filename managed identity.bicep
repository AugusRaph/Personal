@description('Location for all resources.')
param location string = resourceGroup().location

@description('Name of the SQL Server.')
param sqlServerName string

@description('SQL Server administrator login username.')
param sqlAdminUsername string

@description('SQL Server administrator login password.')
param sqlAdminPassword string

resource sqlServer 'Microsoft.Sql/servers@2022-02-01-preview' = {
  name: sqlServerName
  location: location
  properties: {
    administratorLogin: sqlAdminUsername
    administratorLoginPassword: sqlAdminPassword
    publicNetworkAccess: 'Enabled'
  }
  identity: {
    type: 'SystemAssigned'
  }
}

output sqlServerName string = sqlServer.name
output sqlServerFullyQualifiedDomainName string = sqlServer.properties.fullyQualifiedDomainName
output systemAssignedPrincipalId string = sqlServer.identity.principalId
output systemAssignedTenantId string = sqlServer.identity.tenantId