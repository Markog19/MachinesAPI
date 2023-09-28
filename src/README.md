# Machine Maintenance Web API

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

# Introduction

The Machine Maintenance Web API is built to support the monitoring and maintenance of machines and their related issues. It provides a set of RESTful endpoints to manage machines and issues without using the Entity Framework, instead opting for a micro ORM.
Features

The API offers the following essential features:
Machines

# API Documentation


## Create Machine

Endpoint:`POST /machine/post`

Creates a machine.

Request:

 Method: POST
URL: `/machine/post`
Body: JSON object of a `Machine`:

```json
{
    "Id": 1,
    "Name": "Machine1",
}
```
Response:

    200 OK if the machine is created successfully.
    400 Bad Request if there's an issue with the request.

## Delete Machine

Endpoint: DELETE /machine/delete

Deletes a machine by name.

Request:

    Method: DELETE
    URL: /machine/delete
    Body: string name: e.g. "Machine1"

Response:

    200 OK with the deleted machine if successful.
    400 Bad Request if there's an issue with the request.

## Update Machine

Endpoint: PUT /machine/put

Updates a machine's name.

Request:

    Method: PUT
    URL: /machine/put
    Body: JSON object with OldMachineName (string) and NewMachineName (string):

json

{
    "OldMachineName": "Machine1",
    "NewMachineName": "MachineNewName"
}

Response:

    200 OK if the machine is updated successfully.
    400 Bad Request if there's an issue with the request.

## Get Machine

Endpoint: GET /machine/get

Retrieves a machine by name.

Request:

    Method: GET
    URL: /machine/get
    Body: string field: e.g. "Machine1"


Response:

    200 OK with the machine if found.
    400 Bad Request if there's an issue with the request.

## Create Failure

Endpoint: POST /failure/post

Creates a failure.

Request:

    Method: POST
    URL: /failure/post
    Body: JSON object of a Failure:

json

{
        "Name": "Machine Defect 1111",
        "MachineName": "Machine A",
        "Priority": 3,
        "StartTime": "2023-09-25T10:00:00",
        "EndTime": "2023-09-25T12:00:00",
        "Description": "This is defect 1 description.",
        "IsRemoved": false
}

Response:

    200 OK if the failure is created successfully.
    400 Bad Request if there's an issue with the request.

## Delete Failure

Endpoint: DELETE /failure/delete

Deletes a failure by name.

Request:

    Method: DELETE
    URL: /failure/delete
    Body: string field: e.g. "Failure1"


Response:

    200 OK with a success message if the failure is deleted successfully.
    400 Bad Request if there's an issue with the request.

## Update Failure

Endpoint: PUT /failure/put

Updates a failure's name.

Request:

    Method: PUT
    URL: /failure/put
    Body: JSON object with Failure (Failure object) and FailureName (string):

json

{
    "Failure":{
        "Name": "Machine Defect 1111",
        "MachineName": "Machine A",
        "Priority": 3,
        "StartTime": "2023-09-25T10:00:00",
        "EndTime": "2023-09-25T12:00:00",
        "Description": "This is defect 1 description.",
        "IsRemoved": false
    },
    "FailureName": "Machine Defect 1"
    
}

Response:

    200 OK if the failure is updated successfully.
    400 Bad Request if there's an issue with the request.

## Get Failure

Endpoint: GET /failure/get

Retrieves a failure by name.

Request:

    Method: GET
    URL: /failure/get
    Body: name string: e.g. "Failure1"


Response:

    200 OK with the failure if found.
    400 Bad Request if there's an issue with the request.

## Update Status

Endpoint: PUT /failure/status

Updates the status of a failure.

Request:

    Method: PUT
    URL: /failure/status
    Body: JSON object with FailureName (string) and NewStatus (boolean):

json

{
    "FailureName": "Failure1",
    "NewStatus": true
}

Response:

    200 OK if the status is updated successfully.
    400 Bad Request if there's an issue with the request.
Notes
# Machines

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

