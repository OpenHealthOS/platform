# Database Strategy

## Decision Summary
The platform should follow a one-database-per-service approach.

## Proposed Model
- Identity: PostgreSQL
- Patient: Cosmos DB
- FHIR: Cosmos DB
- Audit: Cosmos DB
- Notification: PostgreSQL
- AI Runtime: Blob storage plus Cosmos DB metadata

## Rationale
- Identity benefits from relational constraints and strong consistency.
- Clinical and document-oriented data maps well to document storage.
- Services remain independently deployable and own their own persistence concerns.

## Principle
No service should depend on another service's database directly. Inter-service data exchange should use APIs or events.
