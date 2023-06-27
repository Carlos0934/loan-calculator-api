# Loan Calculator

This is a api loan calculator that calculates the monthly payment, total payment, and total interest of a loan based on the loan amount, interest rate, and loan term. Also included is a loan amortization schedule that shows the monthly payment, interest, principal, and balance for each month of the loan.


## Setup
- Clone the repo

```bash
    git clone https://github.com/Carlos0934/loan-calculator-api
```

- Install dependencies

```bash
    dotnet restore
```

- Run the app

```bash
    cd Api
```

And then

```bash
    dotnet run
```

## Run the tests

```bash
    cd Api.Tests
```

And then

```bash
    dotnet test
```

## Run the app with docker

```bash
    docker-compose up
```

## Usage

Make a get request to the api with the following query parameters to get the loan information:

- Principal: The amount of the loan
- Term: The length of the loan in months
- InterestRate: The interest rate of the loan
- AmortizationType: The type of amortization. Can be either French, American or German.

Example:

```bash
 curl 'http://localhost:{port}/loan/calculate?Principal=1000&Term=12&InterestRate=5&AmortizationType=French'
```
Response with: 
```json 
{
    "amortizations" : [
        {   
            "paymentNumber": 1,
            "interest": 50,
            "principal": 62.825493,
            "balance": 937.1745,
            "amount": 112.82549,
            "paymentNumber": 1
        },
        ... 
    ],
    "amount" : 1353.90459,
    "interest" : 353.9046,
}
```

## License

[MIT](https://choosealicense.com/licenses/mit/)






