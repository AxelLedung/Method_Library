# Interactive Code Demonstration Platform

This project is an interactive web-based platform designed to allow users to experiment with custom methods and classes across different programming languages. Built with `.NET Core`, it serves as an educational tool where users can learn by writing and running code in real-time.

## Project Structure

- **Backend**: ASP.NET Core API
- **Frontend**: Blazor with SignalR for real-time feedback
- **Code Execution**: Docker containers to run Python, Java, and .NET code in isolated environments
- **Database**: SQL Server (for user data, code snippets, and execution logs)
- **Authentication**: ASP.NET Identity for user management and security
- **Deployment**: Docker Compose for local development, with options for deployment on Azure/AWS/GCP

## Features

1. **Interactive Code Editor**: Users can write code in .NET, Java, and Python and run it to see results instantly.
2. **Real-Time Execution Feedback**: Using SignalR for real-time WebSocket communication, code output is returned directly to the browser.
3. **User Authentication & Profiles**: Users can register, log in, and save code snippets to their profiles.
4. **Sample Code Library**: A library of sample methods and classes for each language is available for users to explore.
5. **Containerized Code Execution**: Each language environment runs in a Docker container, ensuring isolated and secure code execution.
6. **Database for Code Snippets**: Users can save, retrieve, and share code snippets they create.

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