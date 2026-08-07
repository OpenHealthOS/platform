# OpenHealthOS Platform — Context

**Repository:** OpenHealthOS/platform  
**Scope:** Core OpenHealthOS Platform  
**Version:** 1.1  
**Status:** Active  
**Last Updated:** 2026-08-07

---

# 1. PURPOSE

This document is the source of truth for the implementation and current
state of the OpenHealthOS platform repository.

For overall OpenHealthOS ecosystem information, see:

    OpenHealthOS/.github/OPENHEALTHOS_CONTEXT.md

---

# 2. PLATFORM ROLE

The platform repository provides the core cloud-native backend and
infrastructure for OpenHealthOS.

It provides:

- APIs
- gateway
- healthcare services
- identity
- FHIR
- clinical data services
- infrastructure
- observability
- security
- events

---

# 3. TECHNOLOGY

Primary:

- .NET 10
- C#
- ASP.NET Core
- Minimal APIs

Infrastructure:

- Azure Cosmos DB
- Docker
- Docker Hub
- GitHub Actions

Gateway:

- YARP

Observability:

- OpenTelemetry
- Serilog
- Seq

Development:

- VS Code
- GitHub Copilot

---

# 4. ARCHITECTURE

The platform uses:

- microservices
- cloud-native architecture
- event-driven architecture
- API-first design
- vertical slice architecture
- modular building blocks

---

# 5. SOLUTION STRUCTURE

Current conceptual structure:

    src/
    tests/
    BuildingBlocks/
    Gateway/
    docs/
    infrastructure/

Exact structure must follow the current repository source tree.

---

# 6. BUILDING BLOCKS

Current/planned:

    OpenHealthOS.SharedKernel
    OpenHealthOS.Contracts
    OpenHealthOS.Infrastructure
    OpenHealthOS.Security
    OpenHealthOS.Observability
    OpenHealthOS.ServiceDefaults
    OpenHealthOS.Hosting

---

# 7. OPENHEALTHOS.HOSTING

Purpose:

Common application hosting and bootstrap configuration.

Target:

    OpenHealthHost.CreateBuilder(args)

Responsibilities:

- configuration
- environment
- hosting defaults
- dependency injection bootstrap

---

# 8. OPENHEALTHOS.SERVICEDEFAULTS

Purpose:

Provide consistent service-level defaults.

Capabilities:

- health checks
- readiness
- liveness
- OpenTelemetry
- structured logging
- correlation IDs
- Problem Details
- exception handling
- HTTP client defaults
- API conventions

Target:

    builder.Services.AddOpenHealthServiceDefaults();

    app.UseOpenHealthPipeline();

---

# 9. GATEWAY

Technology:

- ASP.NET Core
- Minimal APIs
- YARP

Responsibilities:

- routing
- API entry point
- service routing
- observability
- authentication integration
- authorization integration
- future rate limiting

The gateway must remain thin.

---

# 10. API STANDARD

Services should provide:

    /health
    /ready
    /live

APIs should use:

- Minimal APIs
- OpenAPI
- Scalar
- API versioning
- RFC 9457 Problem Details

---

# 11. OBSERVABILITY

Platform-wide observability should include:

- structured logging
- distributed tracing
- metrics
- correlation IDs
- health checks

Target stack:

    OpenTelemetry
    Serilog
    Seq

---

# 12. DATABASE

Primary database:

    Azure Cosmos DB

The persistence architecture should keep database-specific concerns inside
infrastructure layers.

Domain logic must not depend directly on Cosmos DB.

---

# 13. EVENTS

Future event infrastructure:

    Azure Service Bus

Examples:

    PatientCreated
    PatientUpdated
    ObservationCreated
    AIAnalysisCompleted

Events must be versioned and documented.

---

# 14. SECURITY

Planned:

- JWT
- authentication
- authorization
- RBAC
- permissions
- service-to-service authentication
- API keys
- OpenID Connect
- SMART on FHIR readiness

---

# 15. COMPLETED EPICS

## Epic 0

COMPLETED

Organization foundation.

## Epic 1

COMPLETED

Repository foundation.

## Epic 2

COMPLETED

Documentation foundation.

## Architecture Sprint

COMPLETED

Architecture established.

## Epic 3

COMPLETED

Platform foundation and building blocks.

## Epic 4

COMPLETED

Cloud-native gateway foundation.

---

# 16. EPIC 4 COMPLETION

Epic 4 delivered:

- Hosting
- ServiceDefaults
- observability
- API platform
- gateway foundation
- YARP

The Gateway serves as the reference implementation for future services.

---

# 17. NEXT EPIC

## Epic 5 — Identity

Expected areas:

- authentication
- JWT
- refresh tokens
- RBAC
- permissions
- service authentication
- OpenID Connect
- SMART on FHIR readiness

Exact implementation should be designed before coding.

---

# 18. CODING RULES

Prefer:

- small services
- minimal APIs
- vertical slices
- dependency inversion
- async APIs
- cancellation tokens
- immutable contracts where practical
- explicit configuration
- automated tests

Avoid:

- unnecessary abstractions
- static global state
- direct database access from endpoints
- service implementation dependencies
- speculative microservices

---

# 19. PR RULE

Every PR should:

- build successfully
- pass tests
- update documentation when needed
- preserve architecture
- include meaningful commit/PR description

Large architectural changes should have an ADR.

---

# 20. PLATFORM CONTEXT RECOVERY

For a new AI/ChatGPT session:

Upload:

    OpenHealthOS/.github/OPENHEALTHOS_CONTEXT.md

Then:

    OpenHealthOS/platform/OPENHEALTHOS_CONTEXT.md

For detailed implementation, also provide the relevant files under:

    docs/
    docs/architecture/
    ADRs

---

# END