Infermedica

https://developer.infermedica.com/docs/quickstart

Medical concept:
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

It's very important to understand that the /diagnosis endpoint is stateless. This means that the API does not track the state or progress of cases it receives, so with each request you need to send all the information gathered about the patient to this point

![image](https://cloud.githubusercontent.com/assets/1849690/22884768/487b1be2-f1ff-11e6-992c-4131d40eed53.png)
