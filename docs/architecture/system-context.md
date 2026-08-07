# System Context

## Purpose
This document describes the high-level context of the OpenHealthOS platform and the major actors and systems that interact with it.

## Primary Actors
- End users interacting with the platform through a client experience.
- Internal platform teams operating and maintaining services.
- External systems that integrate with OpenHealthOS through APIs and events.

## High-Level Interaction Model
Users interact with a client experience that communicates with a gateway layer. The gateway routes requests to domain-oriented services such as Identity, Patient, FHIR, AI Runtime, Data Quality, Audit, and Notification. These services may also exchange events and integrate with shared data stores and AI providers.

## Architectural View
The platform is intended to be modular and service-oriented, with independent capabilities that can evolve without tightly coupling every component together.

## Key Principle
OpenHealthOS should be understandable from the outside as a health-focused platform that exposes practical APIs, supports integration patterns, and enables extensibility through services and plugins.
