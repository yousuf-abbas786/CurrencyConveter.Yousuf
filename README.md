# Currency Converter APIs

<br>

## How to Run

<br>

`Https: https://localhost:15001` <br>
`Http: http://localhost:15101` 

1. Ensure you have .NET 8 SDK installed.
2. Clone the repository.
3. Navigate to the CC.WebAPIs directory.
4. Run the application using `dotnet run`.
5. The API helper page will be available at `/swagger/index.html`.

<br>

## Endpoints

### Latest
### `GET /api/Currencies/latest`
- This endpoint returns the latest rates. Rates quote against the `EUR` by default.

- You can quote against other currencies using the `from` parameter. <br>
`/api/Currencies/latest?from=USD` <br>

- `to` limits returned rates to specified values. <br>
`/api/Currencies/latest?to=GBP,CAD`
<br>

### Convert
### `GET /api/Currencies/convert` 
- You can convert any value between currencies using the above endpoints in combination with the `amount` parameter.

- Below, we convert 10 British Pounds to US Dollars. <br>
`/api/Currencies/convert?from=GBP&to=USD&amount=10`

- You can convert from single to multiple currencies by passing more currencies inside `to` parameter. <br>
`/api/Currencies/convert?from=GBP&to=USD,CAD&amount=10`

- `from` is optional, it sets `EUR` by default.

- Certain currencies (TRY, PLN, THB, MXN) are not supported for conversion and will return a bad response.
<br>

### Historical
### `GET /api/Currencies/historical?startDate=2020-01-01&endDate=2020-01-31&page=1&pageSize=10`
- This endpoint returns a set of historical rates for a given time period. You can navigate the record sets by using `page` and `pageSize` parameters, also you will get the `totalRecords` count everytime in the response. `page` and `pageSize` are optional, it sets `1` and `10` respectively by default.

- If you omit the `endDate` date, it will return all dates up to the present. <br>
`/api/Currencies/historical?startDate=2020-01-01&page=1&pageSize=10`

- With a full list of currencies, the response grows large in size. For better performance, use the `to` parameter to limit result to rates you are interested in. <br>
`/api/Currencies/historical?to=GBP,CAD&startDate=2020-01-01&endDate=2020-01-31&page=1&pageSize=10`

- `from` is optional, it sets `EUR` by default.

- It returns all data points for up to 90 days. Above that, it starts sampling by week or month based on the breadth of the date range.
<br>

## Tests

1. Navigate to the CC.WebAPIs.Test directory.
2. Run the tests using `dotnet test`.

<br>


## Assumptions

- The API may not respond to the first request, hence retry logic is implemented.
- Pagination is implemented on the historical rates endpoint.
- A cache is implemented on all APIs to improve performance and availability.
- A retry method is implemented on all APIs to retry the requests to Frankfurter APIs three times.

<br>

## Enhancements

- Caching could be further enhanced. Currently, it is using In-Memory cache, but we can also utilize Distributed Cache (e.g., Redis, SQL). Additionally, it could be improved to employ `asynchronous refresh`, refreshing the cache in the background after a specific time range for each request without disrupting the request flow.
- Validations could also be enhanced.
- More unit test could be written.
