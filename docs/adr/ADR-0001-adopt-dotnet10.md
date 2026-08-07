# ADR-0001: Adopt .NET 10, ASP.NET Core, C#, Clean Architecture, Microservices, and Azure-first Cloud Deployment

- Status: Accepted
- Date: 2026-08-06

## Context
OpenHealthOS is intended to become a modular, secure, and interoperable platform for health data and intelligent services. The platform must support strong typing, maintainability, integration with modern cloud infrastructure, and long-term extensibility without locking the organization into a single vendor.

The team needs a technology baseline that is modern, well-supported, and suitable for building distributed services that can evolve over time. The stack must also support a future mix of API-driven systems, background processing, and AI-enabled capabilities.

## Decision
We will use the following architectural and technology choices as the foundation for the platform:

- .NET 10 as the primary application runtime for backend services.
- ASP.NET Core for HTTP APIs, web integration, and service endpoints.
- C# as the primary implementation language for platform services and shared application logic.
- Clean Architecture as the structural approach for organizing code around domain boundaries, use cases, and abstractions.
- Microservices as the preferred deployment style for independently evolving capabilities, with service boundaries aligned to domain responsibilities.
- An Azure-first deployment posture, while keeping the solution cloud-agnostic where practical so services can be migrated or run in other environments when needed.

## Rationale
These choices provide a strong balance of developer productivity, maintainability, ecosystem maturity, and platform flexibility. .NET and ASP.NET Core offer a modern application stack with strong tooling, performance, and enterprise readiness. C# provides expressive, strongly typed development suitable for complex business domains.

Clean Architecture helps isolate core domain logic from infrastructure concerns, making the system easier to evolve and test. Microservices align with the need to build independently deployable capabilities such as identity, patient data, FHIR integration, audit, and AI workflows.

An Azure-first strategy allows the team to start with a practical cloud-native deployment model while keeping the application architecture portable enough to support hybrid or multi-cloud adoption later.

## Consequences
### Positive
- Strong developer productivity and a mature ecosystem.
- Clear separation between business logic and infrastructure concerns.
- Better fit for building scalable, modular services.
- Easier integration with modern Azure services, observability tools, and deployment automation.

### Trade-offs
- Microservices introduce operational complexity, including service ownership, deployment coordination, and distributed monitoring.
- Clean Architecture requires discipline and deliberate boundary design.
- Azure-first choices may require platform-specific implementation decisions in some scenarios.

## Alternatives Considered
- Using a single monolithic application for all capabilities.
- Adopting a different runtime such as Java or Node.js as the primary baseline.
- Choosing a cloud-specific deployment model without portability considerations.

## Notes
This ADR establishes the initial technical direction for the platform and will be revisited as the system grows and operational experience increases.
