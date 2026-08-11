# OpenHealthOS Identity Contracts

## Purpose

This document defines the platform-level identity contracts used across
OpenHealthOS.

The contracts provide common terminology and representations for
authentication and authorization without coupling consuming components
to a specific identity provider or authentication implementation.

## Design Principles

- Authentication and authorization remain separate concerns.
- OAuth clients and security principals are distinct concepts.
- Human users and workloads use the same platform identity model.
- AI systems are represented as workloads rather than a separate identity system.
- Organization and tenant contexts remain distinct.
- Identity contracts must remain independent of infrastructure.
- Identity contracts must not depend on OpenIddict, ASP.NET Core Identity,
  JWT implementation details, or a database provider.

## Principal Types

### User

Represents a human user interacting with OpenHealthOS.

Examples:

- Clinician
- Researcher
- Administrator
- Developer

### Service

Represents a backend service or automated service identity.

### Workload

Represents an automated workload operating within the platform.

Examples:

- AI inference workload
- Background processing workload
- Data processing pipeline
- Plugin execution workload

## Client Types

A client represents the application or workload requesting access.

Client and principal are not necessarily the same identity.

For example:

```text
Client:
    OpenHealthOS Web Application

Principal:
    Human User