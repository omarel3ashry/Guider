<div align="center">
  <a href="https://github.com/omarel3ashry/Guider">
    <img src="assets/GuiderLogo.png" alt="Logo" width="100" height="100">
  </a>
  <h3 align="center"></h3>
  <p align="center">
    Guiding You Towards Expertise, One Consultation at a Time!
  </p>
</div>

# Guider Backend API

Welcome to Guider Backend API repository! This API serves as the backend for the Guider web application, facilitating interactions between consultants and clients through various features.

## Key Features

1. **User Registration and Profiles**
   - Consultants and Clients can register and manage detailed profiles.
   - Consultant profiles highlight skills, experience, and expertise.
   - Client profiles manage bookings and view consultation history.

2. **Service Listings**
   - Consultants can list services and set hourly rates.
   - Integrated calendar for specifying available hours.
   - Services categorized by fields (e.g., IT, Finance, Health) for easy navigation.

3. **Booking and Payment System**
   - Secure booking system for clients to schedule consultations.
   - Payment processing through secure gateways for transaction safety.

4. **One-on-One Video Meetings**
   - Integrated WebRTC for seamless one-on-one video conferencing.

5. **Ratings**
   - Clients can rate consultants after sessions, providing feedback.
   
## Technologies Used

- [ASP.NET Core Web API](https://learn.microsoft.com/en-us/aspnet/core/web-api): A rich framework for building web apps and APIs using the MVC design pattern.
- [SQL Server](https://www.microsoft.com/en-us/sql-server/): A proprietary relational database management system developed by Microsoft.
- [Entity Framework (EF) Core](https://learn.microsoft.com/en-us/ef/core/): An object-relational mapping (ORM) framework developed by Microsoft.
- [MediatR](https://www.nuget.org/packages/MediatR): Simple, unambitious mediator implementation in .NET
- [WebRTC](https://webrtc.org/): Technology for real-time communication.
- [SignalR](https://dotnet.microsoft.com/en-us/apps/aspnet/signalr): An open-source, real-time messaging framework developed by Microsoft.
- [HangFire](https://www.hangfire.io/): An easy way to perform background processing in .NET and .NET Core applications.
- [Stripe](https://stripe.com/): Payment processing API for secure transactions.
- [Identity](https://learn.microsoft.com/en-us/aspnet/core/security/authentication/identity): an API that manages users, passwords, profile data, roles, claims, tokens, email confirmation, and more.
- [Serilog](https://serilog.net/): Logging framework.
- [AutoMapper](https://automapper.org/): object-object mapper. Takes out all of the fuss of mapping one object to another.
- [FluentValidation](https://fluentvalidation.net/): .NET library for building strongly-typed validation rules.

## Architecture and Patterns

- **Clean Architecture**: Separation of concerns and layering for maintainability.
- **CQRS (Command Query Responsibility Segregation)**: Separates read and write operations.
- **Mediator Pattern**: Centralized request handling.
- **Repository Pattern**: Abstraction layer over data access.

## Contributors
The dedicated developers whose hard work brought this project to life.
<table>
  <tr>
    <td align="center" valign="top" width="14%"><a href="https://github.com/Mo3bdelrahman" style:"border-radius:50%;"><img src="https://avatars.githubusercontent.com/u/61760258?v=4"  width="100px;" /><br /><sub><b>Mohamed Abdelrahman</b></sub></a><br /></td>
    <td align="center" valign="top" width="14%"><a href="https://github.com/NohaAbdelalim" style:"border-radius:50%;"><img src="https://avatars.githubusercontent.com/u/157377341?v=4"  width="100px;" /><br /><sub><b>Noha Abdelalim</b></sub></a><br /></td>
    <td align="center" valign="top" width="14%"><a href="https://github.com/yasmeena1999" style:"border-radius:50%;"><img src="https://avatars.githubusercontent.com/u/45334675?v=4"  width="100px;" /><br /><sub><b>Yasmeen Hassan</b></sub></a><br /></td>
    <td align="center" valign="top" width="14%"><a href="https://github.com/hossameltayeb83" style:"border-radius:50%;"><img src="https://avatars.githubusercontent.com/u/96459585?v=4"  width="100px;" /><br /><sub><b>Hossam Eltayeb</b></sub></a><br /></td>
    <td align="center" valign="top" width="14%"><a href="https://github.com/nourhanbelal22" style:"border-radius:50%;"><img src="https://avatars.githubusercontent.com/u/157370503?v=4"  width="100px;" /><br /><sub><b>Nourhan Belal</b></sub></a><br /></td>
    <td align="center" valign="top" width="14%"><a href="https://github.com/karimalshal666" style:"border-radius:50%;"><img src="https://avatars.githubusercontent.com/u/157370888?v=4"  width="100px;" /><br /><sub><b>Karim Alshal</b></sub></a><br /></td>
    <td align="center" valign="top" width="14%"><a href="https://github.com/omarel3ashry" style:"border-radius:50%;"><img src="https://avatars.githubusercontent.com/u/32119955?v=4"  width="100px;" /><br /><sub><b>Omar Elashry</b></sub></a><br /></td>
  </tr>
</table>

<br/>

## Installation

To run Guider locally, follow these steps:

1. **Clone the repository:**
   
   ```
   git clone https://github.com/omarel3ashry/Guider
   ```
   
3. **Navigate to the project directory:**
   
   ```
   cd Guider
   ```
   
4. **Install dependencies:**
   
   ```
   dotnet restore
   ```
   
5. **Create the database using Entity Framework Core:**
   
   ```
   dotnet ef database update
   ```
   
7. **Build and Run:**
   
   ```
   dotnet build
   dotnet run
   ```
**Note:** Make sure you have [.NET Core SDK](https://dotnet.microsoft.com/en-us/download) installed on your system.
