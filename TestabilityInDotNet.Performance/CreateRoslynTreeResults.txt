|               Method |     Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 |  Gen 1 |  Gen 2 | Allocated |
|--------------------- |---------:|---------:|---------:|------:|--------:|-------:|-------:|-------:|----------:|
| CreateTreeViaParsing | 11.50 us | 0.147 us | 0.123 us |  1.00 |    0.00 | 1.3885 | 0.3662 | 0.1221 |   6.31 KB |
| CreateTreeViaFactory | 24.93 us | 0.450 us | 0.421 us |  2.17 |    0.05 | 3.1738 | 0.8240 | 0.1831 |  15.17 KB |