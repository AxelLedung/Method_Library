# Method Library

This project is an interactive web-based platform designed to allow users to store their most useful methods and classes across different programming languages. 
Built with `.NET Core`, it serves as an helpful tool where the user can find already developed methods and classes made for generic purposes. 
For example to extract from JSON in a specific way or a method for creating error log files at a preferred directory. 

## Project Structure

- **Backend**: ASP.NET Core API
- **Database**: SQL Server (for user data, code snippets, and execution logs)
- **Authentication**: ASP.NET Identity for user management and security

## Features

1. **Sample Code Library**: A library of sample methods and classes for each language is available for users to explore.
2. **Database for Code Snippets**: Users can save and retrieve code snippets they create.

## Technology Stack

- **.NET Core 9**: Core framework for the backend API components.
- **SQL Server**: Database for user profiles, saved code snippets, and execution logs.

## Prerequisites

- **.NET SDK 6** or higher
- **SQL Server** (or Docker container for SQL Server)

## Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/AxelLedung/Method_Library.git
cd Method_Library
