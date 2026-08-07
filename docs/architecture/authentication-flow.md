# Authentication Flow

## Overview
Authentication should be coordinated through the gateway and identity service so that downstream services can trust a validated identity context.

## Proposed Flow
1. A user authenticates through a client experience.
2. The request is routed through the gateway.
3. The identity service validates the user and issues a token.
4. The gateway forwards the token to downstream services.
5. Microservices consume and validate the identity context as needed.

## Future Expansion
The platform can later support SMART-on-FHIR, Entra ID, Keycloak, and other OpenID Connect-based identity providers.
