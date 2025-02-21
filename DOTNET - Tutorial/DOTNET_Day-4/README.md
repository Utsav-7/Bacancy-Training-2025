# DOTNET Tutorial : Day - 4 
## Problem Statement: 
- Develop a weather application API that fetches weather data based on a city name while implementing request restrictions, logging. The system should use middleware to block requests specifically for Ahmedabad, returning a restricted access response. Additionally, all incoming requests and outgoing responses must be logged to the console for monitoring. The API should also store the JSON weather data of successful requests into a file for future reference.

## Approch: 
- I have implement Dependency injection for IWriteData for write data in file. And IReadData for reading data from file.
## Excution Path: 
- Program.cs &harr; LogMiddleware &harr; CheckMiddleware &harr; GET Method &harr; Fetch data from file
- Program.cs &harr; LogMiddleware &harr; CheckMiddleware &harr; Post Method &harr; Fetch data through API

## Output: 
![Screenshot 2025-02-21 134010](https://github.com/user-attachments/assets/29bae406-dd8c-4ba7-8f53-049c8985f4b8)
![Screenshot 2025-02-21 134049](https://github.com/user-attachments/assets/6337d993-dcac-44f1-bc92-14707be16802)
![Screenshot 2025-02-21 134122](https://github.com/user-attachments/assets/f6c6186a-a17f-4649-b8ea-458a0ccac478)
![Screenshot 2025-02-21 134151](https://github.com/user-attachments/assets/4daa00eb-861f-45c6-ae27-fca3ed150c48)
