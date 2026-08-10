# ADR-0003: Identity Architecture

- **Status:** Accepted
- **Date:** 2026-08-09
- **Decision Owners:** OpenHealthOS Architecture
- **Related Areas:** Security, Gateway, APIs, FHIR, AI Runtime
- **Related ADRs:**
  - ADR-0000 Engineering Principles
  - ADR-0001 Adopt .NET 10
  - ADR-0002 AI Runtime

## 1. Problem

OpenHealthOS must provide a consistent and secure way to identify who is calling the platform and what those callers are allowed to do. Without a shared identity model, services would independently implement authentication and authorization logic, creating inconsistent access control, weak auditability, and poor interoperability across healthcare APIs, applications, and AI integrations.

## 2. Goals

- Establish a common identity model for human users, services, applications, and AI systems.
- Separate authentication from authorization so each concern can evolve clearly.
- Support secure access to FHIR resources, platform APIs, and internal services.
- Enable role-based and policy-based access control.
- Provide a foundation compatible with healthcare interoperability patterns such as SMART on FHIR.
- Preserve auditability, least-privilege access, and tenant-aware security boundaries.

## 3. Non-Goals

- Defining a full enterprise IAM implementation in this ADR.
- Choosing a specific commercial identity provider.
- Defining every clinical workflow permission model in detail.
- Solving non-identity security concerns such as network isolation or endpoint hardening.

## 4. Identity Actors

### Human Users

Human users include clinicians, administrators, developers, researchers, and other operators interacting with the platform through web applications, admin tools, or developer workflows.

### Service Accounts

Service accounts represent automated components such as background jobs, data pipelines, integration workers, or platform services that need to act on behalf of the system.

### External Applications

External applications include third-party healthcare systems, partner integrations, custom clients, and mobile or web applications that access OpenHealthOS APIs.

### Principal Model

```
                     Principal
                        │
         ┌──────────────┼──────────────┐
         │              │              │
         ▼              ▼              ▼
      Human           Service        Application
       User           Identity         Client
```

OpenHealthOS will treat every authenticated caller as a security
principal.

A principal may represent:

- A human user
- A service identity
- An external application
- An automated workload

AI systems should generally be represented as service or workload
identities rather than receiving a separate security model.

This allows the same authentication and authorization infrastructure to
protect APIs regardless of whether the caller is a human, application,
background worker, or AI service.

### Principal and Client Distinction

An OAuth client represents an application or workload requesting access
to OpenHealthOS. A security principal represents the identity on whose
behalf an authorization decision is evaluated.

In some flows, the client and principal may represent the same workload.
In delegated user flows, the client and the user principal are distinct.

Authorization decisions must therefore distinguish between:

- The requesting client
- The authenticated subject
- The effective principal
- The requested scopes and permissions

## 5. Authentication

Authentication answers the question:

> Who are you?

OpenHealthOS should support a standards-based authentication model in which every caller is identified through a trusted identity assertion. The platform should be able to authenticate:

- Human users
- Service accounts
- External applications
- Healthcare applications
- AI services

The authentication model should support token-based flows and be compatible with modern identity standards such as OAuth 2.0 and OpenID Connect where appropriate.

## 6. Authorization

Authorization answers the question:

> What are you allowed to do?

Once an identity is established, the platform must evaluate whether that identity can perform a requested action. Examples of permissions include:

- Read Patient
- Write Patient
- Read Observation
- Run AI analysis
- Administer organization

Authorization should be policy-driven and enforceable consistently at the API, service, and resource layers.

### Resource-Level Authorization

Authorization should eventually support decisions based on:

- Principal
- Organization
- Role
- Permission
- Scope
- Resource
- Resource ownership or relationship
- Tenant boundary
- Policy context

For healthcare resources, authorization may need to determine not only
whether a caller can read a resource type, but whether the caller can
access a specific resource within an authorized organizational or patient
context.

## 7. Token Strategy

OpenHealthOS will use short-lived access tokens for runtime authorization.
Refresh or reauthentication mechanisms may be used where appropriate.

Access tokens should contain only the minimum identity and authorization
context required by downstream services.

Recommended principles:

- Use signed tokens with clear issuer and audience claims.
- Use short-lived access tokens.
- Keep tokens scoped to the minimum necessary access.
- Validate issuer, audience, signature, expiration, and relevant claims.
- Avoid placing sensitive clinical information in access tokens.
- Prefer token rotation and reauthentication mechanisms over attempting to
  maintain a centralized revocation list for every JWT access token.
- Support immediate credential/client revocation where security requirements
  require it.
- Ensure authentication and authorization events remain auditable.

### Token Revocation

OpenHealthOS will primarily rely on short-lived access tokens.

Revocation requirements will be handled at the appropriate layer:

- Access tokens: short lifetime
- Refresh tokens: rotation and revocation where applicable
- Client credentials: immediate client/credential revocation
- User credentials: account/session revocation where required
- High-risk security events: additional token/session invalidation mechanisms
  may be introduced when necessary

## 8. Roles

Roles should represent coarse-grained responsibilities such as:

- Administrator
- Clinician
- Researcher
- Developer
- Integration Partner
- Service Operator

Roles may be assigned to users or service identities and should be composed into permissions through a policy layer.

Roles are not considered sufficient for authorization decisions on their
own.

Services should prefer explicit permissions and authorization policies
over direct role checks.

For example, services should prefer:

```
patient.read
```

over:

```
if user.Role == "Clinician"
```

This is especially important given the range of principal types the platform must support:

- Clinician
- Researcher
- AI Service
- Integration Partner
- Administrator

## 9. Permissions

Permissions represent the specific actions that can be performed within the system. They should be defined in a way that is explicit, testable, and reusable across services.

Examples include:

- Read patient records
- Write clinical observations
- Trigger AI analysis workflows
- Manage tenant configuration
- View audit logs

## 10. Scopes

Scopes should be used to express delegated access for clients and external applications. They provide a bounded view of access and help prevent over-privileged tokens.

Example scopes may include:

- patient.read
- patient.write
- observation.read
- ai.analyze
- organization.admin

## 11. Organization / Tenant Model

OpenHealthOS should support multi-tenant and multi-organization scenarios. Identity and authorization decisions should be evaluated in the context of a tenant or organization boundary so that users and services cannot access resources outside their assigned scope.

The model should support:

- Organization-level roles and permissions
- Tenant-specific policy evaluation
- Clear separation of data and administrative boundaries

### Organization and Tenant Distinction

An organization represents a real-world or logical entity participating
in OpenHealthOS, such as a healthcare provider, research institution,
or integration partner.

A tenant represents an isolated security and data boundary within the
platform.

An organization may own or participate in one or more tenants depending
on the deployment and business model.

The initial implementation may use a one-organization-to-one-tenant
mapping while keeping the domain model extensible for future
multi-organization scenarios.

## 12. Service-to-Service Authentication

Platform services and internal workloads should authenticate each other using non-user identities or workload identities. This is necessary for secure inter-service communication, background processing, and integration pipelines.

Recommended approach:

- Use workload identity or service identity credentials.
- Enforce mutual authentication where appropriate.
- Apply least-privilege access to downstream service calls.

## 13. Security Audit

The identity architecture should produce auditable decisions. Authentication and authorization events should be recorded in a way that supports incident investigation, compliance review, and operational monitoring.

Audit considerations include:

- Who authenticated
- What token or credential was used
- What action was requested
- Whether access was granted or denied
- Which policy decision was applied

## 14. SMART on FHIR Readiness

OpenHealthOS should be designed to support healthcare interoperability patterns such as SMART on FHIR. This means the platform should be compatible with OAuth-based delegated access, well-defined scopes, and standards-aligned identity flows for healthcare applications.

SMART on FHIR readiness should eventually support concepts such as:

- OAuth 2.0 authorization
- OpenID Connect where applicable
- SMART scopes
- PKCE
- Authorization server discovery
- FHIR resource scopes
- User-level and patient-level authorization context
- EHR launch context
- Standalone launch flows

These capabilities are not implemented in this phase. This section establishes the architectural intent so that design decisions remain compatible with SMART on FHIR as the platform evolves.

## 15. Technology Decision

OpenHealthOS will adopt an identity architecture centered on standards-based authentication, token-based authorization, policy-driven permissions, and tenant-aware access control. The platform should be able to integrate with modern identity providers while preserving a clear internal model for services and applications.

### Explicit technology choices

```
              OpenHealthOS Identity
                       │
          ┌────────────┴────────────┐
          │                         │
          ▼                         ▼
ASP.NET Core Identity          OpenIddict
          │                         │
   Users / Passwords          OAuth 2.0 / OIDC
   Roles / Claims             Tokens / Scopes
          │                         │
          └────────────┬────────────┘
                       ▼
                Identity Service
```

- Identity and user management: ASP.NET Core Identity
- OAuth 2.0 / OpenID Connect server: OpenIddict
- Authentication protocol: OAuth 2.0 + OpenID Connect
- Access token format: JWT
- Authorization: ASP.NET Core policy-based authorization
- Service authentication: OAuth 2.0 client credentials / workload identity
- Future healthcare authorization: SMART on FHIR

### Architecture Overview

```
                     OpenHealthOS
                          │
                          ▼
                   🔐 Identity Layer
                          │
          ┌───────────────┼────────────────┐
          │               │                │
          ▼               ▼                ▼
        Human          Service          Client
        User           Identity        Application
          │               │                │
          └───────────────┼────────────────┘
                          ▼
                     Authentication
                          │
                 OAuth 2.0 / OIDC
                          │
                          ▼
                     OpenIddict
                          │
                          ▼
                     Access Token
                          │
                ┌─────────┴─────────┐
                ▼                   ▼
           Gateway              Services
                │                   │
                ▼                   ▼
         Token Validation     Authorization
                                    │
                     ┌──────────────┼──────────────┐
                     ▼              ▼              ▼
                   Tenant       Permission      Resource
                   Policy         Policy         Policy
                     │              │              │
                     └──────────────┼──────────────┘
                                    ▼
                              Healthcare APIs
                                    │
                         ┌──────────┼──────────┐
                         ▼          ▼          ▼
                       FHIR        AI        Data
                                    │
                                    ▼
                          Least-Privilege AI
```

## 16. Alternatives Considered

Alternative approaches include:

- Per-service custom authentication logic
- Static shared secrets for all service interactions
- Role-only access control without policy granularity
- Treating identity as an afterthought in service development

These alternatives were rejected because they increase complexity, weaken security, and reduce interoperability.

## 17. Security Boundaries

OpenHealthOS will enforce security at multiple layers:

```
Client
   │
   ▼
Gateway
   │
   ├── Authentication
   ├── Token validation
   └── Request policy
          │
          ▼
       Service
          │
          ├── Authorization
          ├── Tenant validation
          └── Resource authorization
                 │
                 ▼
              Data
```

No individual service should assume that authentication performed by another
component is sufficient for all authorization decisions.

Services remain responsible for enforcing authorization relevant to their
resources.

### AI Workload Authorization

AI services are treated as untrusted workloads from an authorization
perspective. An AI service must receive only the minimum data and permissions
required for the requested operation.

```
❌ AI Service
      │
      ▼
  Entire Patient Database

✅ AI Service
      │
      ▼
  Authorized clinical context
      │
      ▼
  Specific analysis
```

This principle applies to all AI capabilities including clinical NLP,
predictive analysis, and clinical decision-support.

## 18. Security Considerations

Identity design must account for:

- Token theft and replay
- Privilege escalation
- Overly broad scopes
- Weak service-to-service trust
- Insecure secret storage
- Insufficient audit coverage

The platform should apply defense-in-depth principles and favor least-privilege defaults.

## 19. Future Evolution

As the platform grows, the identity model should evolve to support:

- Federated identity across organizations
- External partner onboarding
- Fine-grained attribute-based access control
- Richer AI-specific authorization models
- Stronger governance and policy lifecycle management
