# Service Boundaries

## Guiding Principle
FHIR is not the domain model. Internal services should maintain their own domain models and translate to and from FHIR when needed.

## Proposed Service Responsibilities
- Gateway: routing, rate limiting, authentication forwarding, and ingress coordination.
- Identity: users, roles, authentication, authorization primitives, and identity-related workflows.
- Patient: patient domain concerns and application-facing patient logic.
- FHIR: HL7 FHIR resource handling, interoperability, and transformation.
- AI Runtime: orchestration of model execution and provider selection.
- AI Registry: model metadata, versioning, provenance, licensing, evaluation metrics, and deployment status.
- Data Quality: validation, scoring, and quality checks.
- Audit: immutable audit trail and compliance-oriented event recording.
- Notification: email, SMS, webhook, and other notification channels.

## Design Rule
Each service should have a single responsibility and own its data. Cross-service coordination should occur through contracts, APIs, and events rather than shared databases.
