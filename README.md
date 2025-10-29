#  RestApiTests

Automated REST API testing project built with **C#**, **NUnit**, **RestSharp**, and **FluentAssertions**.  
It validates endpoints from the free [JSONPlaceholder API](https://jsonplaceholder.typicode.com), covering all major HTTP methods and verifying proper response handling.

---

##  Overview

This project demonstrates API automation best practices including:
- Configuration-driven base URL (`appsettings.json`)
- Tests for **GET**, **POST**, **PUT**, and **DELETE**
- Response code and content validation
- One **negative test** for invalid endpoints
- Clean, scalable NUnit structure

---

##  Requirements

Before running the tests, ensure you have:
- [.NET SDK 9.0+](https://dotnet.microsoft.com/en-us/download)
- An IDE or editor such as **Visual Studio Code**
- Internet connection (for JSONPlaceholder API)

---

##  Project Structure

```
RestApiTests/
│
├── Tests/
│   └── JsonPlaceholderTests.cs    # Main test suite
│
├── appsettings.json               # Config file for base URL
├── RestApiTests.csproj            # Project definition
└── README.md                      # This file
```

---

## ⚡ Setup Instructions

### 1 Clone or Download
If using Git:
```bash
git clone https://github.com/<your-username>/RestApiTests.git
cd RestApiTests
```

Or, download the folder directly from your GitHub repository.

---

### 2 Restore Dependencies
Run this command to install required NuGet packages:
```bash
dotnet restore
```

---

### 3 Build the Project
```bash
dotnet build
```

You should see:
```
Build succeeded.
```

---

### 4 Run the Tests
Execute all NUnit tests:
```bash
dotnet test
```

Expected output:
```
Passed!  - Failed: 0, Passed: 5, Skipped: 0, Total: 5
```

---

##  Notes

- The base URL is defined in `appsettings.json`:
  ```json
  {
    "BaseUrl": "https://jsonplaceholder.typicode.com"
  }
  ```
  You can modify this if you want to test a different API.

- Tests automatically validate:
  - Correct HTTP status codes  
  - Expected response body contents  
  - Proper handling of invalid endpoints (404 errors)

---

##  Author

**Michael Gentry**   
[GitHub Profile](https://github.com/mgentry3035)

---

##  Example Test Summary

| Test Name | HTTP Method | Expected Result |
|------------|--------------|----------------|
| Get_Posts_ShouldReturn200 | GET | 200 OK |
| Post_CreateNewPost_ShouldReturn201 | POST | 201 Created |
| Put_UpdateExistingPost_ShouldReturn200 | PUT | 200 OK |
| Delete_Post_ShouldReturn200 | DELETE | 200 OK |
| Get_InvalidEndpoint_ShouldReturn404 | GET (invalid) | 404 Not Found |

---

 **Run, verify, and explore API automation fundamentals in a clean, reusable C# test project.**
