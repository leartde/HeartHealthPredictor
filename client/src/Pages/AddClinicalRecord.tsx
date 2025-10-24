import React, { useEffect, useState } from 'react';
import type { Patient } from "../Types/Patient.ts";
import type { Doctor } from "../Types/Doctor.ts";
import FetchAllPatients from "../Services/Patient/FetchAllPatients.ts";
import fetchAllDoctors from "../Services/Doctor/FetchAllDoctors.ts";
import CreateClinicalRecord from "../Services/ClinicalRecord/CreateClinicalRecord.ts";
import { useNavigate } from "react-router";

type ClinicalRecordForm = {
  patientId: number;
  recordedByDoctorId: number;
  chestPainType: number;
  restingBloodPressure: number;
  cholesterolTotal: number;
  fastingBloodSugar: number;
  restEcg: number;
  maximumHeartRate: number;
  exerciseInducedAngina: boolean;
  oldPeak: number;
  slope: number;
  majorVesselsColored: number;
  thalassemia: number;

}

const AddClinicalRecord = () => {
  const [patients, setPatients] = useState<Patient[]>([]);
  const navigate = useNavigate();
  useEffect(() => {
    const getPatients = async () =>{
      const data = await FetchAllPatients();
      setPatients(data);
    }
    getPatients().then()
  }, []);
  const [doctors, setDoctors] = useState<Doctor[]>([])
  useEffect(() => {
    const getDoctors = async () =>{
      const data = await fetchAllDoctors();
      setDoctors(data);
    }
    getDoctors().then()
  }, []);

  const [formData, setFormData] = useState<Partial<ClinicalRecordForm> >({
    restingBloodPressure: 120,
    cholesterolTotal: 200,
    fastingBloodSugar: 90,
    maximumHeartRate: 150,
    exerciseInducedAngina: false,
    oldPeak: 1.0,
    numberOfMajorVessels: 0
  })
  const handleInputChange = (e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>) => {
    const { name, value, checked } = e.target;

    setFormData(prev => ({
      ...prev,
      [name]: name === 'exerciseInducedAngina'
        ? checked
        : Number(value)
    }));
  };

  const handleSubmit = async(e)=>{
    e.preventDefault();
    console.log(formData)
    const result  = await CreateClinicalRecord(formData);
    if(result){
      navigate("/clinical-records");
    }
  }

  return (
    <form onSubmit={handleSubmit} className="flex flex-col bg-green-200/80 rounded-md p-4 text-gray-600 gap-2">
      <legend className="text-xl font-bold text-green-800 mb-4">Add Clinical Record</legend>
      <div className="w-96 flex justify-between">
        <label className="text-lg" htmlFor="doctorId"> Doctor </label>
        <select className="bg-gray-200 px-2 w-42" onChange={handleInputChange} id="recordedByDoctorId"
                name="recordedByDoctorId"
                value={formData.recordedByDoctorId}>
          <option>---</option>
          {doctors.map((doctor) => (
            <option key={doctor.id} value={doctor.id}>{doctor.firstName + " " + doctor.lastName}</option>
          ))}
        </select>
      </div>
      <div className="w-96 flex justify-between">
        <label className="text-lg" htmlFor="patientId"> Patient </label>
        <select className="bg-gray-200 px-2 w-42" onChange={handleInputChange} id="patientId" name="patientId"
                value={formData.patientId}>
          <option>---</option>
          {patients.map((patient) => (
            <option key={patient.id} value={patient.id}>{patient.firstName + " " + patient.lastName}</option>
          ))}
        </select>
      </div>

      <div className="w-96 flex justify-between">
        <label className="text-lg" htmlFor="chestPainType"> Chest pain type </label>
        <select className="bg-gray-200 px-2 w-42" onChange={handleInputChange} id="chestPainType" name="chestPainType"
                value={formData.chestPainType}>
          <option>---</option>
          <option value={1}> Typical Angina</option>
          <option value={2}> Atypical Angina</option>
          <option value={3}> Non-anginal pain</option>
          <option value={4}> Asymptomatic</option>

        </select>
      </div>

      <div className="w-96 flex justify-between">
        <label className="text-lg" htmlFor="restingBloodPressure">Resting blood pressure</label>
        <input defaultValue={120} onChange={handleInputChange} className="bg-gray-200 px-2 w-42" min={80} max={210} type="number"
               name="restingBloodPressure"
               value={formData.restingBloodPressure!} id="restingBloodPressure"/>
      </div>

      <div className="w-96 flex justify-between">
        <label className="text-lg" htmlFor="cholesterolTotal"> Cholesterol total </label>
        <input defaultValue={200} onChange={handleInputChange} value={formData.cholesterolTotal!} className="bg-gray-200 px-2 w-42" min={100}
               max={600} type="number" name="cholesterolTotal"
               id="cholesterolTotal"/>
      </div>

      <div className="w-96 flex justify-between">
        <label className="text-lg" htmlFor="fastingBloodSugar"> Fasting blood sugar</label>
        <input defaultValue={90} className="bg-gray-200 px-2 w-42" onChange={handleInputChange} type="number"
               id="fastingBloodSugar" name="fastingBloodSugar"
               value={formData.fastingBloodSugar!} min={70}
               max={200}
        />
      </div>
      <div className="w-96 flex justify-between">
        <label className="text-lg" htmlFor="fastingBloodSugar">
          Resting ECG results
        </label>
        <select className="bg-gray-200 px-2 w-42 h-7" onChange={handleInputChange} id="restEcg" name="restEcg"
                value={formData.restEcg}>
          <option>---</option>
          <option value={0}> Normal</option>
          <option value={1}> Having ST-T wave abnormality</option>
          <option value={2}> Showing probable or definite left ventricular hypertrophy by Estes' criteria</option>
        </select>
      </div>

      <div className="w-96 flex justify-between">
        <label className="text-lg" htmlFor="maximumHeartRate"> Maximum heart rate</label>
        <input className="bg-gray-200 px-2 w-42" onChange={handleInputChange} type="number"
               id="maximumHeartRate" name="maximumHeartRate"
               value={formData.maximumHeartRate!} min={70}
               max={220}
               defaultValue={150}
        />
      </div>

      <div className="w-96 flex gap-4">
        <label  className="text-lg" htmlFor="exerciseInducedAngina">Exercise Induced Angina</label>
        <input
          type="checkbox"
          id="exerciseInducedAngina"
          name="exerciseInducedAngina"
          checked={formData.exerciseInducedAngina}
          onChange={handleInputChange}
        />

      </div>

      <div className="w-96 flex justify-between items-center">
      <label className="text-lg" htmlFor="oldPeak">ST depression induced<br/> by exercise</label>
        <input className="bg-gray-200 px-2 w-42 h-7" onChange={handleInputChange} type="number"
               id="oldPeak" name="oldPeak"
               value={formData.oldPeak!} min={0.0}
               step={0.1}
               max={6.5}
               defaultValue={1.0}
        />
      </div>

      <div className="w-96 flex justify-between">
        <label className="text-lg" htmlFor="fastingBloodSugar">
          Slope of the peak<br/> exercise ST segment
        </label>
        <select className="bg-gray-200 px-2 w-42 h-7" onChange={handleInputChange} id="slope"
                name="slope"
                value={(formData.slope)}>
          <option>---</option>
          <option value={1}> Uplsoping</option>
          <option value={2}>Flat</option>
          <option value={3}>Downsloping</option>
        </select>
      </div>

      <div className="w-96 flex justify-between items-center">
        <label className="text-lg" htmlFor="oldPeak">Number of colored<br/> major vessels</label>
        <input className="bg-gray-200 px-2 w-42 h-7" onChange={handleInputChange} type="number"
               id="majorVesselsColored" name="majorVesselsColored"
               value={formData.majorVesselsColored!} min={0}
               max={3}
               defaultValue={0}
        />
      </div>

      <div className="w-96 flex justify-between">
        <label className="text-lg" htmlFor="fastingBloodSugar">
          Thalassemia
        </label>
        <select className="bg-gray-200 px-2 w-42 h-7" onChange={handleInputChange} id="thalassemia"
                name="thalassemia"
                value={(formData.thalassemia)}>
          <option>---</option>
          <option value={3}>Normal</option>
          <option value={6}>Fixed defect</option>
          <option value={7}>Reversible defect</option>
        </select>
      </div>

      <div className="w-48 p-2">
      <button type="submit" className="w-full rounded-md bg-green-500/80 cursor-pointer hover:bg-green-700/80 text-white font-semibold p-1">Submit</button>
      </div>

    </form>
  );
};

export default AddClinicalRecord;
