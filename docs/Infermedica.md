Infermedica

https://developer.infermedica.com/docs/quickstart

Medical concept (**domain**):
* Conditions
* Symptoms
* Lab tests and lab test results
* Risk factors

```json
{
  "updated_at": "2016-11-18T12:19:19Z",
  "conditions_count": 479,
  "symptoms_count": 1103,
  "risk_factors_count": 39,
  "lab_tests_count": 438
}
```

https://developer.infermedica.com/docs/api#/

API|description
----|-------------
Conditions | 
 | GET /conditions
 | GET /conditions/{id}
Diagnosis | 
 | POST /diagnosis
Explain | 
 | POST /explain
Info | 
 | GET /info
Lab_tests |
 | GET /lab_tests
 | GET /lab_tests/{id}
Lookup |
 | GET /lookup
Parse |
 | POST /parse
Risk_factors |
 | GET /risk_factors **including url to image**
 | GET /risk_factors/{id} **including url to image**
Search |
 | GET /search
Symptoms | 
 | GET /symptoms **including url to image**
 | GET /symptoms/{id} **including url to image**
 Triage |
 | POST /triage 
------------------
NOTES:
It's very important to understand that the /diagnosis endpoint is stateless. This means that the API does not track the state or progress of cases it receives, so with each request you need to send all the information gathered about the patient to this point

Apart from the /diagnosis endpoint, the Infermedica API provides a complementary /triage endpoint that can categorize provided patient cases based on the seriousness of reported observations and the severity of likely conditions. This procedure may be viewed as similar to the telephone triage, hence the name of this endpoint.

![image](https://cloud.githubusercontent.com/assets/1849690/22884768/487b1be2-f1ff-11e6-992c-4131d40eed53.png)
