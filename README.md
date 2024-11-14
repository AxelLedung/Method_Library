# Method Library

This project is an interactive web-based platform designed to allow users to store their most useful methods and classes across different programming languages. 
Built with `.NET Core`, it serves as an helpful tool where the user can find already developed methods and classes made for generic purposes. 
For example to extract from JSON in a specific way or a method for creating error log files at a preferred directory. 

## Project Structure

- **Backend**: ASP.NET Core API
- **Frontend**: Blazor with SignalR for real-time feedback
- **Code Execution**: Docker containers to run Python, Java, and .NET code in isolated environments
- **Database**: SQL Server (for user data, code snippets, and execution logs)
- **Authentication**: ASP.NET Identity for user management and security
- **Deployment**: Docker Compose for local development, with options for deployment on Azure/AWS/GCP

## Features

1. **Sample Code Library**: A library of sample methods and classes for each language is available for users to explore.
2. **Database for Code Snippets**: Users can save and retrieve code snippets they create.

## Technology Stack

- **.NET Core 6**: Core framework for the backend API and Blazor components.
- **Blazor**: Interactive front-end framework for building single-page applications (SPA) in .NET.
- **SignalR**: Real-time bi-directional communication for sending code execution output to the client.
- **Docker**: Containerization for handling code execution in .NET, Java, and Python environments.
- **SQL Server**: Database for user profiles, saved code snippets, and execution logs.

## Prerequisites

- **.NET SDK 6** or higher
- **Docker** (for containerized code execution)
- **SQL Server** (or Docker container for SQL Server)

## Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/yourusername/interactive-code-platform.git
cd interactive-code-platform
