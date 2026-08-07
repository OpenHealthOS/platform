# AI Runtime and AI Registry

## Design Direction
The AI layer should be split into two responsibilities:

- AI Runtime: model execution, provider selection, inference, and plugin orchestration.
- AI Registry: model metadata, versions, provenance, licensing, evaluation metrics, and deployment status.

## Principles
- The AI Runtime should never depend on a specific framework behind a model.
- AI providers should be interchangeable.
- The system should support multiple runtimes and providers while keeping the application layer stable.

## Initial Runtime View
The AI runtime may integrate with implementations such as PyHealth, ONNX Runtime, and Hugging Face while preserving a consistent abstraction layer for the rest of the platform.
