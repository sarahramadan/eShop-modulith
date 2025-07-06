# ADR 001: Use Manual Reflection vs. Scrutor for CQRS Handler Registration

**Date:** 2025-07-06  
**Status:** Proposed  
**Deciders:** Team Lead, Backend Team  
**Reviewers:** Architecture Committee

---

## 1. Context

We are implementing the CQRS pattern in our .NET application. Each command or query has a corresponding handler, and we need a scalable, maintainable way to register these handlers with the Dependency Injection (DI) container.

There are two primary approaches:

- **Scrutor**: A third-party NuGet package for scanning and registering services using reflection.
- **Manual Reflection**: A custom-built solution using .NET's built-in reflection APIs to find and register services.

This decision must account for long-term maintainability, performance, runtime compatibility, and readiness for NativeAOT scenarios.

---

## 2. Decision

We will **[select one]**:

- ✅ Use **Manual Reflection** to register CQRS handlers using our own `AddCqrsHandlersFromAssembly()` method.
- ⬜ Use Scrutor for automatic DI registration.

---

## 3. Rationale

| Criteria                  | Scrutor                              | Manual Reflection                         |
|---------------------------|--------------------------------------|-------------------------------------------|
| Simplicity                | ✅ Easy and clean                     | ⚠️ Slightly more setup code               |
| External Dependency       | ❌ Adds a NuGet package               | ✅ No extra packages                       |
| AOT Compatibility         | ❌ May break in NativeAOT             | ✅ Fully compatible                        |
| Performance               | ✅ Optimized                          | ⚠️ Slight startup cost if not cached      |
| Control / Customization   | ⚠️ Limited                            | ✅ Full control                            |
| Discoverability           | ✅ Familiar to most .NET devs         | ⚠️ Requires documentation                 |
| Long-Term Support         | ✅ Maintained by open source          | ✅ Maintained in-house                     |

We prioritize flexibility and NativeAOT compatibility in this case, which tips the balance in favor of Manual Reflection.

---

## 4. Implications

### Choosing Manual Reflection:
- Adds 50–100 lines of reusable setup code.
- Avoids any compatibility issues with AOT or dynamic code restrictions.
- Can be fully customized for things like filtering by namespace, attribute, or lifetime.

### If we had chosen Scrutor:
- Setup would be faster and cleaner.
- We'd risk compatibility issues in NativeAOT or minimal-host environments.
- We'd depend on third-party library updates and behavior.

---

## 5. Related Decisions

- ADR-002: NativeAOT vs JIT runtime strategy
- ADR-003: Modular service registration via DI extension methods

---

## 6. Consequences

- All handler registration logic will live in our shared CQRS library via extension methods.
- New developers will require guidance/documentation on how automatic registration works.
- If the .NET team expands NativeAOT support, we’re already compatible.

---

## 7. Decision Outcome

- [ ] Accepted
- [ ] Rejected
- [ ] Superseded by ADR-___
- [ ] Reviewed on YYYY-MM-DD

---
