# 🔐 DAX IdentityServer

**DAX IdentityServer** is a sandbox implementation of [Duende IdentityServer](https://duendesoftware.com/) designed for exploring and managing OAuth2 / OpenID Connect clients within a distributed architecture setup.

This repository is part of the **DAX (Distributed Architecture eXamples)** project and serves as the authentication and authorization core in the sandbox ecosystem.

---

## 🎯 Purpose

This project makes it easy to:

- Experiment with OAuth2 and OpenID Connect flows
- Register and manage identity clients in a simple, editable way
- Prototype login, token issuance, and validation for APIs and frontends
- Understand the role of an Identity Provider in microservices

---

## 🧪 Key Features

- ✅ Sandbox-friendly setup using Duende IdentityServer
- ✅ In-memory or JSON-based client/resource configuration
- ✅ Optional custom user store and login logic
- ✅ Ideal for testing BFF, SPA, and API auth scenarios
- ✅ Fast local development with `dotnet run`

---

## 🚀 Quickstart

```bash
git clone https://github.com/mengio001/DaxIdentityServer.git
cd DaxIdentityServer
dotnet run
```

Once running, the IdentityServer UI will be available at:

```
https://localhost:5001
```

Use this as your authority URL for other DAX components (e.g., BFFs, APIs, SPAs).

---

## 🛠 Tech Stack

- [.NET 8](https://dotnet.microsoft.com/)
- [Duende IdentityServer](https://duendesoftware.com/)
- OAuth 2.1 / OpenID Connect
- ASP.NET Core
- Optional: Entity Framework Core (for production scenarios)

---

## 📂 Project Structure

| Folder / File                      | Purpose                              |
|------------------------------------|--------------------------------------|
| `QuizTower-IDP/`                  | Main IdentityServer code             |
| `appsettings.*.json`              | Config files per environment         |
| `Services/LocalUserService.cs`    | Custom user store logic (optional)   |
| `Config.cs`                       | Client and resource definitions      |
| `HostingExtensions.cs`            | IdentityServer service setup         |

---

## 💡 Why "DAX"?

**DAX** stands for **Distributed Architecture eXamples**, a GitHub showcase of modular, sandboxed apps simulating real-world system architecture using microservices and modern protocols.

---

## 📜 License

This sandbox project is intended for **educational and experimental** purposes only. It uses Duende IdentityServer under the terms of their [license](https://duendesoftware.com/license).

---

## 🤝 Contributing

This project is part of a personal exploration. Suggestions or forks welcome! Just keep in mind the educational purpose of the repository.
