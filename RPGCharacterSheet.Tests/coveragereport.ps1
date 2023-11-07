dotnet test --collect:"XPlat Code Coverage"

$CoverageDirectory = Get-ChildItem -Recurse -path *.cobertura.xml | % { $_.Directory }

reportgenerator -reports:"$CoverageDirectory\coverage.cobertura.xml" -targetdir:"coveragereport" -reporttypes:Html

Remove-Item -LiteralPath "TestResults\$CoverateDirectory" -Force -Recurse