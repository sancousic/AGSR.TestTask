## Entity sample

```
Patient:
{
    "name":
    {
        "id" : "d8ff176f-bd0a-4b8e-b329-871952e32e1f",
        "use": "official",
        "family": "Иванов",
        "given": [
            "Иван",
            "Иванович"
        ]
    },
    "gender": "male",
    "birthDate": "2024-01-13T18:25:43",
    "active": true
}
```

## Required fields

 - Name.Family
 - birthDate

 ## Enums

- Gender: male | female | other | unknown
- Active: true | false

## Search pacient

- By birthDate [with requirenment](https://www.hl7.org/fhir/search.html#date)

## Other requirenments

Logig parts:

 - .NET Core app for API, .NET 6, any DBMS, Swagger (with method descriptions).
 - Console .NET Core app to generate 100 Patient entities.
- Postman collection (create, update, get by id, delete, some serch by date)