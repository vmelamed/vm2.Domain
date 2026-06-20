#!/usr/bin/env dotnet

// SPDX-License-Identifier: MIT
// Copyright (c) 2025-2026 Val Melamed

#:property TargetFramework=net10.0
#:project ../src/Domain/Domain.csproj

using static System.Console;

using vm2.Domain;

WriteLine("Domain example");
WriteLine(DomainApi.Echo("hello", "fallback"));
WriteLine(DomainApi.Echo(null, "fallback"));
