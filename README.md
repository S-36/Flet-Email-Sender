
## Description

A test project for sending emails using a C# ASP.NET Core backend API and a Python Flet frontend GUI. The backend provides REST endpoints for email sending, while the frontend offers a simple interface to compose and send emails.

## Features

- Send emails via SMTP (configured for Gmail)
- RESTful API with Swagger documentation
- Simple GUI built with Flet
- Console logging middleware

## Prerequisites

- .NET 9.0 SDK
- Python 3.x
- A Gmail account (or other SMTP provider)

## Installation

### Backend Setup

1. Navigate to the `Backend/` directory.
2. Restore dependencies:
   ```
   dotnet restore
   ```
3. Set environment variables for email credentials:
   - `EMAIL_USER`: Your SMTP username (e.g., your Gmail address)
   - `EMAIL_PASSWORD`: Your SMTP password (use an app password for Gmail)
   - `EMAIL_FROM`: The from email address

   You can set these in your system environment or use a `.env` file with DotNetEnv.

### Frontend Setup

1. Navigate to the `Frontend/app/` directory.
2. Install Python dependencies:
   ```
   pip install flet requests python-dotenv
   ```
3. Create a `.env` file and set:
   ```
   BACKEND_URL=http://localhost:5000/api/Email
   ```
   (Adjust the URL based on your backend's running port)

## Usage

### Running the Backend

1. In the `Backend/` directory, run:
   ```
   dotnet run
   ```
2. The API will be available at `https://localhost:5001` (or as configured in `launchSettings.json`).
3. Access Swagger UI at `https://localhost:5001/swagger` for API documentation.

### Running the Frontend

1. In the `Frontend/app/` directory, run:
   ```
   python main.py
   ```
2. A GUI window will open. Enter the recipient's email, subject, and body, then click "Send Email".

## API Endpoints

- `POST /api/Email`: Send an email
  - Body: JSON with `to`, `subject`, `body`
- `GET /api/Email`: Check email settings (placeholder)

## Configuration

- SMTP settings are hardcoded for Gmail in `EmailCollection.cs`. Modify as needed for other providers.
- Update `appsettings.json` for additional configuration.

## Notes

This is a test project. Ensure your SMTP credentials are secure and consider using environment variables or secure vaults in production.