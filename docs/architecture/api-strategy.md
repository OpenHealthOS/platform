# API Strategy

## Goals
The platform should expose consistent, versioned, and observable APIs across services.

## Conventions
- Use RESTful resource-oriented routes.
- Version APIs through a consistent prefix such as /api/v1.
- Provide standard health endpoints from the start:
  - /health
  - /ready
  - /metrics

## Proposed Routes
- /api/v1/patients
- /api/v1/fhir
- /api/v1/models
- /api/v1/identity

## Design Principles
- Keep APIs backward compatible where practical.
- Favor explicit contracts and clear semantics.
- Make observability a first-class concern.
