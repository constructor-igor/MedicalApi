# MedicalApi
Medical API feasibility

<B>References</B>

webmd.com
symptoms checker

* http://apimedic.com/ (samples in sources: https://github.com/priaid-eHealth/symptomchecker)
* http://sym.doctors.co.il/sites/sym.doctors.co.il/html/sc.html#frame-4th
* http://infermedica.com

* https://www.programmableweb.com/category/medical/api
* http://stackoverflow.com/questions/34871386/is-there-a-good-medical-api-out-there
* https://www.quora.com/What-is-the-best-API-for-medical-diagnosis
* https://www.drchrono.com/api/

* https://www.babylonhealth.com

**http://apimedic.com/**
![image](https://cloud.githubusercontent.com/assets/1849690/22407188/6a6a6370-e66a-11e6-9c4f-29fb99879bc6.png)

![image](https://cloud.githubusercontent.com/assets/1849690/22407517/833e35e2-e670-11e6-818c-e3b54c507f90.png)
![image](https://cloud.githubusercontent.com/assets/1849690/22407518/89af0f3c-e670-11e6-8ba9-f8d1363a1e28.png)

GET|description
----|-------------
/symptoms | Symptoms can be either called to receive the full list of symptoms or a subset of symptoms (e.g. all symptoms of a body sublocation).
/issues | Issues can be either called to receive the full list of issues or a subset of issues (e.g. all issues of a diagnosis).
/issues/104/info | Issue info can be called to receive all information about a health issue. The short description gives a short overview. A longer information can consist of "Description", "MedicalCondition", "TreatmentDescription".
/diagnosis | The diagnosis is the core function of the symptom-checker to compute the potential health issues based on a set of symptoms, gender and age.
/specialisations | The diagnosis is the core function of the symptom-checker to compute the potential health issues based on a set of symptoms, gender and age, but instead of getting computed diagnosis, you can also get list of suggested specialisations for calulated diseases
/symptom/proposed | The proposed symptoms can be called to request additional symptoms which can be related to the given symptoms in order to refine the diagnosis.
/body/locations | Body locations can be called to receive all the body locations
/body/locations/16 | Body sublocations can be called to receive all the body sub locations from a body location.
/symptoms/0/man | Symptoms in body sublocations can be called to receive all the symptoms in a body sub location.
/redflag | Red flag texts are recommendations to the patient for a higher urgency or severeness of the possible symptoms. As an example a patient with pain in the breast might have a heart attack and therefore the patient should be warned about the urgency and severeness of the matter.
------------
