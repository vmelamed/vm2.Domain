// SPDX-License-Identifier: MIT
// Copyright (c) 2025-2026 Val Melamed

namespace vm2.Benchmarks.Domain;

#if SHORT_RUN
[ShortRunJob]
#else
[SimpleJob(RuntimeMoniker.HostProcess)]
#endif
public class EchoBenchmarks
{
    private string _value = "payload";

    [Benchmark]
    public string Echo_Value() => DomainApi.Echo(_value, "fallback");

    [Benchmark]
    public string Echo_Fallback() => DomainApi.Echo(null, "fallback");
}
