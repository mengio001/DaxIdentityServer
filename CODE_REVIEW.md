# Code Review | Zelfevaluatie



## SPRINT 1  

### Zelf evaluatie

|               | CODE    |TEST   |DEVOPS  | USER STORIES AAN GEWERKT |
|---------------|---------|-------|--------|---------------------------------------------------|
| Ozkan Mengi   |  😀    |  👎  |  👎    |- [#1 - As a user, I want to be able to register so that I can access the platform](https://gitlab.fdmci.hva.nl/project-se-dt/2324/team8/QuizTower-IDP/-/commit/87c49284915325bbbbb7d816f0610edbf1272218) <br> - [#3 - As a user, I want to be able login and log-out](https://gitlab.fdmci.hva.nl/project-se-dt/2324/team8/UserManagement/-/commit/67460b418b57c3dba06efb2ab3970f80adee7282) |



### Naam Ozkan Mengi

| Focus 1      | Focus 2    | Focus 3         | Focus 4 | Focus 5 |
| ------------ | ---------- | --------------- | ------- | ------- |
| IDP IdentityProvider | OAuth 2.0. | OpenID Connect (OIDC) | Refresh Tokens | Custom AuthorizationPolicies

##### What went well:

 - Veel security implementaties gedaan samen met refresh token, AuthorizationPolicies.
 - IdentityServer is nu zo goed als klaar om gebruikt te worden voor UserManagement en TowerQuizPlatform.

##### (Even) better if:

 - Test scripts schrijven ben ik niet aan toe gekomen, het was beter geweest als ik ook test scripts had voor automated testing.
 - Build gitlab runners kreeg ik niet aan praat waardoor ik extra uitzoek tijd verloor. Deze moet ik vervolg oppakken samen met Angular setup voor TowerQuizPlatform spel.


#####
#####
#####
#####
###
#


## SPRINT 2  

### Zelf evaluatie

|               | CODE | TEST | DEVOPS | USER STORIES AAN GEWERKT                                     |
| ------------- | ---- | ---- | ------ | ------------------------------------------------------------ |
| Ozkan Mengi   | 😀    | 👎    | 😀      | - [As a DevOps engineer, I want continuous integration and continuous deployment (CI/CD) to facilitate tests automation and deployments.](https://gitlab.fdmci.hva.nl/project-se-dt/2324/team8/QuizTower-IDP/-/merge_requests?scope=all&state=merged) <br> - [As a developer, I want a database for storing user data, quiz data, and game results](https://gitlab.fdmci.hva.nl/project-se-dt/2324/team8/QuizTower-IDP/-/blob/develop/appsettings.json?ref_type=heads) |<br> - [setup Azure Portal - App Services, SQL database, Microsoft Entra ID, Key vaults/api secrets](https://portal.azure.com/#home)<br> - [Setup Azure DevOps CI/CD and pipelines - azure-ci.yml](https://dev.azure.com/towerofquizzes/towerofquizzes)


### Naam Ozkan Mengi

| Focus 1      | Focus 2    | Focus 3         | Focus 4 |
| ------------ | ---------- | --------------- | ------- |
| Azure Portal - App Services | SQL database | Key vaults and Storage account | bug: [02:01:25 Error] Microsoft.EntityFrameworkCore.Database.Connection, An error occurred using the connection to database 'IdentityServerDB' on server 'tcp:quiztower-idp-prd01.database.windows.net,1433'.    |

##### What went well:

- Linking users across IDPs (Federated identity: linking a person's electronic identity and attributes, stored across multiple distinct identity providers)
- User provisioning (The process that ensures users are created, changed, disabled, deleted and/or given the permissions and/or claims they need)
- And Linking a third-party provider (Facebook, Microsoft Entra ID) to an existing local account

##### (Even) better if:

- It would be even better if I could integrate unit tests, end-to-end tests, and the production test plan into the CI/CD process. The pipelines are ready, and placeholders for unit test artifacts have been configured for future implementation.


#####
#####
#####
#####
###
#


## SPRINT 3  

### Zelf evaluatie

|               | CODE | TEST | DEVOPS | USER STORIES AAN GEWERKT                                     |
| ------------- | ---- | ---- | ------ | ------------------------------------------------------------ |
| Ozkan Mengi   | 😀    | 👎    | 😀      | - [As an administrator, I want to manage users (add, edit, delete) to maintain the user database](https://gitlab.fdmci.hva.nl/project-se-dt/2324/team8/UserManagement/-/merge_requests/4/) <br> - [Create an Angular client app with BFF (Backend for Frontend) and API.](https://gitlab.fdmci.hva.nl/project-se-dt/2324/team8/QuizTowerPlatform/-/merge_requests/4/commits) <br> - [As a player, I want to start, play, and complete a quiz](https://gitlab.fdmci.hva.nl/project-se-dt/2324/team8/QuizTowerPlatform/-/commits/TQ-9?ref_type=heads) <br> - [Writing automated test cases - Test-Driven Development (TDD)](https://gitlab.fdmci.hva.nl/project-se-dt/2324/team8/DevOps/-/issues/8) <br> - [Writing/creating end-to-end test cases - Behavioral-Driven Development (BDD)](https://gitlab.fdmci.hva.nl/project-se-dt/2324/team8/DevOps/-/issues/6) |


### Naam Ozkan Mengi

| Focus 1      | Focus 2    | Focus 3         | Focus 4 |
| ------------ | ---------- | --------------- | ------- |
| UserManagement BackendWebApi and SecurityPolicy for admin | QuizTowerPlatform backend, bff and frontend (SPA) | BFF Microsoft YARP proxy | Bugs    |

##### What went well:

 - Usermanagement clientapp afmaken waarbij communicatie via BackendWebApi adapter ging goed. <br />
 - BFF YARP uitzoeken en configuren nam tijd maar uiteindelijk is het goed gegaan. <br />
 - Begin maken aan Quiz GamePlay ging ook wel alleen de kleine details zoals Quiz Resultaat neemt toch veel tijd in. <br />
 - Ik heb voor nu simpel test scripts gemaakt, waardoor het goed ging. Complexe test script heb ik overgeslagen omdat ik alsnog in tijdnood kwam, wegens groot enterprise-architectuur op te zetten. <br />


##### (Even) better if:

- Logout config werkt nog niet zo goed met proxy. Dit kan beter en hiervoor heb ik al nieuwe story gemaakt voor uitzoeken en oplossen. <br />
- Ik heb in code soms voor snelheid TODO: aangemaakt alleen moet ook nog op backlog gezet worden zodat opgepakt kan worden in toekomst. <br />

