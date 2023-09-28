Machine Maintenance Web API

This is a README file for the Machine Maintenance Web API project, implemented in C# using PostgreSQL as the underlying database. This API is designed to facilitate the management of machines and their associated issues or faults.
Table of Contents

    Introduction
    Features
    Getting Started
        Prerequisites
        Installation
    API Endpoints
        Machines
        Issues
    Notes

Introduction

The Machine Maintenance Web API is built to support the monitoring and maintenance of machines and their related issues. It provides a set of RESTful endpoints to manage machines and issues without using the Entity Framework, instead opting for a micro ORM.
Features

The API offers the following essential features:
Machines

    Add Machine
        Endpoint: /machines/post
        Method: POST
        Description: Add a new machine to the database.
        Constraints:
            The machine must have a unique name.

    Delete Machine
        Endpoint: /machines/delete
        Method: DELETE
        Description: Delete a machine by its name.

    Update Machine
        Endpoint: /machines/put
        Method: PUT
        Description: Update machine information.

    Retrieve Machine with Faults
        Endpoint: /machines/getMachines
        Method: GET
        Description: Retrieve details of a machine, including its name, and all associated faults with the average duration of those faults.

Failures

    Add failure
        Endpoint: /failure/post
        Method: POST
        Description: Add a new issue or fault.
        Constraints:
            The failure must have a name, machine name, description, priority, and start time.
            An issue cannot be added if there is an active issue (unresolved fault) on the same machine.

    Delete failure
        Endpoint: /failure/delete
        Method: DELETE
        Description: Delete an issue by its name.

    Update failure
        Endpoint: /failure/put
        Method: PUT
        Description: Update issue information.

    Retrieve failure
        Endpoint: /failure/get
        Method: GET
        Description: Retrieve a list of all issues.

    Change Issue Status
        Endpoint: /failure/status
        Method: PUT
        Description: Change the status of an issue (resolved or unresolved).

    Retrieve Top Issues
        Endpoint: /failures/getFailures
        Method: GET
        Description: Retrieve a specified number of issues sorted by priority (low, medium, high) and then by start time (descending order) for pagination.

Notes
Machines

    Machines must have unique names.
    No duplicate machine names are allowed.

Issues

    Issues must include a name, machine name, description, priority, and start time.
    Issues cannot be added if there is an active issue (unresolved fault) on the same machine.

Getting Started
Prerequisites

To run this project, you need the following:

    Visual Studio or a compatible IDE for C# development.
    PostgreSQL installed and running.

Installation

    Clone this repository to your local machine.
    Open the project in your IDE.
    Build and run the project.

