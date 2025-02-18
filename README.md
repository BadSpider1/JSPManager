# JSPManager

JSPManager is a C# bot designed to manage members of the **Jihočeský Studentský parlament (South Bohemian Students Parliament)**. Currently, it supports member management, and additional features will be added later. The bot is fully configurable through a `config.json` file.

## Features

- **Member Management**: Add, edit, and remove members with configurable roles.
- **Role-Based Permissions**: Members can be assigned different roles with specific permissions.
- **Configurable**: The bot can be easily configured using the `config.json` file.
- **Extensible**: More functionality will be added in future releases to support other organizational features.

## Prerequisites

Before you begin, ensure you have the following installed:

- The executable once i actually put it in realeases should be self-contained

## Config
```json
{
  "Token": "insert-your-token",
  "Groups": [
    {
      "GroupNameHuman": "Výbor pro elektrotechniku",
      "GroupName": "example_group",
      "ChairmenRole": 123456789,
      "MemberRole": 123456789
    },
    {
      "GroupNameHuman": "Výbor pro c#",
      "GroupName": "example_group2",
      "ChairmenRole": 123456789,
      "MemberRole": 123456789
    }
  ],
  "Admins": [
    {
      "admin": 12345
    },
    {
      "admin": 123456789
    }
  ]
}
```
