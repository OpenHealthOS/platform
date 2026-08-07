# Dependency Rules

This document defines the allowed dependency direction for the OpenHealthOS platform architecture.

## Core rule

Dependencies should always point inward toward the domain and shared abstractions.

## Dependency diagram

```text
Gateway
    ↓
BuildingBlocks

Services
    ↓
BuildingBlocks

BuildingBlocks
    ↓
Nothing
```

## Rules

### 1. Gateway layer
- The gateway may depend on building blocks and shared contracts.
- The gateway should not depend on concrete service implementations directly when a shared abstraction is available.

### 2. Services layer
- Services may depend on BuildingBlocks.
- Services must not reference other services directly.
- Communication between services should happen through APIs or events.

### 3. BuildingBlocks layer
- BuildingBlocks are the shared foundation for the platform.
- BuildingBlocks must not depend on application services.
- BuildingBlocks should remain generic and reusable.

### 4. Domain independence
- Domain code should remain independent of infrastructure.
- Domain models and business rules should not depend on databases, HTTP, messaging, or other external frameworks.

### 5. Infrastructure boundaries
- Infrastructure concerns such as persistence, messaging, and external integrations should be implemented behind abstractions.
- Application services may depend on infrastructure implementations through interfaces defined in the domain or shared contracts.

## Guidance

When introducing a new dependency, ask:
- Does it point inward toward the domain?
- Does it avoid coupling services together directly?
- Does it keep infrastructure concerns out of the domain layer?

If a dependency violates these rules, it should be redesigned through abstractions, contracts, or event-based communication.
