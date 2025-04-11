<!-- README.md file version: v0.1.1 -->
<a name="readme-top"></a>

<div align="center">
  <a href="https://github.com/mengio001/DaxIdentityServer">
    <img src="https://avatars.githubusercontent.com/u/67868775?s=48&v=4" alt="Logo" width="80" height="80">
  </a>

  <h3 align="center">DAX IdentityServer</h3>

  <p align="center">
    <strong>Distributed Architecture eXamples – IdentityServer</strong><br />
    A sandbox implementation of Duende IdentityServer for secure OAuth2 / OpenID Connect authentication flows.<br />
    Easily manage auth clients and integrate them into your distributed system design.
  </p>
</div>

<details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
        <li><a href="#built-with">Built With</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
        <li><a href="#installation">Installation</a></li>
      </ul>
    </li>
    <li><a href="#license">License</a></li>
    <li><a href="#contact">Contact</a></li>
    <li><a href="#acknowledgments">Acknowledgments</a></li>
  </ol>
</details>

## About The Project

This folder contains the identity provider of the DAX platform — a modular sandbox environment showcasing secure authentication using Duende IdentityServer.

The implementation provides:
- OAuth2 / OIDC-compliant auth server
- Easy-to-edit in-memory or JSON client configs
- Sandbox-ready flows for APIs, BFFs, SPAs
- Educational and exploratory code structure

### Built With
* [.NET 8](https://dotnet.microsoft.com/)
* [Duende IdentityServer](https://duendesoftware.com/)
* [ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core)

<p align="right">(<a href="#readme-top">back to top</a>)</p>

## Getting Started

### Prerequisites
* .NET 8.0 SDK
* Git

### Installation

1. Clone the repository
```sh
git clone https://github.com/mengio001/DaxIdentityServer.git
```

2. Navigate to the Identity folder
```sh
cd DaxIdentityServer/QuizTower-IDP
```

3. Restore dependencies
```sh
dotnet restore
```

4. Build & run the project
```sh
dotnet run
```

<p align="right">(<a href="#readme-top">back to top</a>)</p>

## License

This project is educational and sandboxed. Duende IdentityServer is subject to its own licensing terms. See [Duende Licensing](https://duendesoftware.com/license) for commercial usage info.

<p align="right">(<a href="#readme-top">back to top</a>)</p>

## Contact

Ozkan Mengi - [LinkedIn](https://www.linkedin.com/in/mengio1990/) - o.mengi@timelessmedia.nl - [timelessmedia.nl](https://timelessmedia.nl)

<p align="right">(<a href="#readme-top">back to top</a>)</p>

## Acknowledgments

* [Duende Software](https://duendesoftware.com/)
* .NET community
* DAX contributors
