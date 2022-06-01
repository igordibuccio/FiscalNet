# FiscalNet
## Brazilian Tax Library

![Badge](https://img.shields.io/static/v1?label=csharp&message=language&color=blue&style=for-the-badge&logo=csharp)
![Badge](https://img.shields.io/static/v1?label=.net6&message=framework&color=blue&style=for-the-badge&logo=.net)
[![Nuget count](https://img.shields.io/nuget/v/FiscalNet)](https://www.nuget.org/packages/FiscalNet/2022.6.1)

[![Build Status](https://travis-ci.org/joemccann/dillinger.svg?branch=master)](https://travis-ci.org/joemccann/dillinger)

## About 
  This project is a library that helps the implementation of tax calculations for issuing electronic tax documents in Brazil. Calculation of ICMS, ICMS-ST, IPI, PIS and COFINS.

This project is built using the CSharp language with .Net Standard and has the test project validating the results. 

## Features

- ICMS calculation
- ICMS-ST calculation
- IPI calculation
- PIS calculation
- COFINS calculation

We recommend that the calculations be validated by the accountant of the company that will use the library.

## Use
```sh
Icms00 icms00 = new Icms00(valorProduto, valorFrete, valorSeguro, despesasAcessorias,
                                       valorIpi, valorDesconto, aliquotaIcmsProprio);

decimal vBC = icms00.BaseIcmsProprio();

decimal vICMS = icms00.ValorIcmsProprio();
```

## Support

Our company is specialized in tax and technical support for software houses. 
Access: https://www.sacfiscal.com.br

| Techs we are supported | Frameworks |
| ------ | ------ |
| C# | ZeusDFe <https://github.com/ZeusAutomacao/DFe.NET> & UniNFe <https://github.com/Unimake/DFe> |
| Delphi | ACBr <https://projetoacbr.com.br/> |
| Lazarus | ACBr <https://projetoacbr.com.br/> |
| PHP | SPEDNFe <https://github.com/nfephp-org/sped-nfe> |


## License

MIT
