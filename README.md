# BookStoreApi

## Overview

**BookStoreApi** is a web-based API that allows users to manage and interact with a digital bookstore using **Minimal APIs** in **ASP.NET Core**. It provides a set of endpoints for performing CRUD (Create, Read, Update, Delete) operations on books and their associated data. The API enables users to retrieve information about books, add new books, update existing books, and delete books from the database.

This project is built using **ASP.NET Core 6** with **Minimal API** approach, **Entity Framework Core** for database access, and **PostgreSQL** as the database. It is designed with best practices for API development, including validation, authentication, and error handling, while leveraging the lightweight and efficient **Minimal API** feature of .NET.

## Features

- **Create**: Add new books to the store with necessary details like title, author, category, and description.
- **Read**: Retrieve a list of books or details of a specific book.
- **Update**: Edit the details of an existing book.
- **Delete**: Remove a book from the store.
- **Error Handling**: Return meaningful error messages for invalid requests.
- **Validation**: Ensure all input data meets predefined constraints.
- **Minimal API**: Utilize the new **Minimal API** style for defining endpoints, improving clarity and reducing boilerplate code.

## Technologies Used

- **ASP.NET Core 6**: Web API framework, using the **Minimal API** approach for building RESTful services with less boilerplate.
- **Entity Framework Core**: Object-Relational Mapping (ORM) for working with the PostgreSQL database.
- **PostgreSQL**: Relational database management system.
- **Swagger/OpenAPI**: API documentation for easy testing and interaction with the API.
- **AutoMapper**: For object-to-object mapping between models and DTOs.
- **FluentValidation**: For validating input data for API endpoints.

## Installation

To get started with **BookStoreApi** locally, follow these steps:

1. Clone the repository:
   ```bash
   git clone https://github.com/monta-20/BookStoreApi.git
