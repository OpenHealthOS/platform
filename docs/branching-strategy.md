# Branching Strategy

## Overview
The repository should use a simple and predictable branching model that supports collaboration while keeping the main branch stable.

## Proposed Model
- Main is the protected branch for production-ready work.
- Short-lived feature branches are created from main for new work.
- Use descriptive branch names such as feature/..., fix/..., or chore/....
- Merge only after review, passing checks, and clear intent.

## Release Branches
Release branches may be introduced later if the platform needs a formal release train or hotfix path.
