Exemplo de CRUD em ASP.NET Core com BD SQLite, para instrumentação com Datadog

Na pasta 
/datadog-crud/src/DatadogCrud.Api

executar:

```bash
dotnet run
```

O crud estará rodando na porta 5011 do seu localhost em um swagger:

http://localhost:5011/swagger/index.html

<img width="1215" height="556" alt="image" src="https://github.com/user-attachments/assets/1f6e3039-6d2c-47e3-ad5f-ab6d05f72d94" />


## Exemplos de Utilização via cURL

```bash
curl -X GET "http://localhost:5011/api/items/" | jq
curl -X POST "http://localhost:5011/api/items" -H "Content-Type: application/json" -d "{\"name\":\"Caneta\",\"description\":\"Verde\"}" | jq
curl -X PUT "http://localhost:5011/api/items/1" -H "Content-Type: application/json" -d "{\"id\":1, \"name\":\"Caneta Preta\", \"description\":\"Ponta fina\"}" | jq
curl -X DELETE "http://localhost:5011/api/items/10" | jq
