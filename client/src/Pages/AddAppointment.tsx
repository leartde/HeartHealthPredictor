import React, { useEffect, useState } from 'react';
import type { Patient } from "../Types/Patient.ts";
import type { Doctor } from "../Types/Doctor.ts";
import FetchAllPatients from "../Services/Patient/FetchAllPatients.ts";
import FetchAllDoctors from "../Services/Doctor/FetchAllDoctors.ts";
import CreateAppointment from "../Services/Appointment/CreateAppointment.ts";
import { useNavigate } from "react-router";

type AppointmentFormData = {
  patientId: number;
  doctorId: number;
  time: string;
};

const AddAppointment = () => {
  const [patients, setPatients] = useState<Patient[]>([]);
  const [doctors, setDoctors] = useState<Doctor[]>([]);
  const [formData, setFormData] = useState<Partial<AppointmentFormData>>({});
  const navigate = useNavigate();
  useEffect(() => {
    const getPatients = async()=>{
      const data = await FetchAllPatients();
      setPatients(data);
    }
    getPatients().then();
  }, []);

  useEffect(() => {
    const getDoctors = async()=>{
      const data = await FetchAllDoctors();
      setDoctors(data);
    }
    getDoctors().then();
  }, []);

  const handleInputChange = (e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>) => {
    const { name, value } = e.target;
    setFormData(prev => ({
        ...prev,
        [name]: value
      })
    )};
  const handleSubmit = async(e: React.FormEvent) =>{
    e.preventDefault();
    const localDateTime = new Date(formData.time!);
    formData.time = localDateTime.toISOString();
    const result = await CreateAppointment(formData);
    if(result)navigate("/appointments");
  }
  return (
    <form onSubmit={handleSubmit} className="flex flex-col bg-green-200/80 rounded-md p-4 text-gray-600 gap-2">
      <legend className="text-xl font-bold text-green-800 mb-4">Add an appointment</legend>

      <div className="w-72 flex justify-between">
        <label className="text-lg" htmlFor="doctorId"> Doctor </label>
        <select className="rounded-md bg-gray-100/80 px-2 w-42" onChange={handleInputChange} id="doctorId"
                name="doctorId"
                value={formData.doctorId}>
          <option>---</option>
          {doctors.map((doctor) => (
            <option key={doctor.id} value={doctor.id}>
              {doctor.firstName} {doctor.lastName}
            </option>
          ))}
        </select>
      </div>

      <div className="w-72 flex justify-between">
        <label className="text-lg" htmlFor="patientId"> Patient </label>
        <select className="rounded-md bg-gray-100/80 px-2 w-42" onChange={handleInputChange} id="patientId"
                name="patientId"
                value={formData.patientId}>
          <option>---</option>
          {patients.map((patient) => (
            <option key={patient.id} value={patient.id}>
              {patient.firstName} {patient.lastName}
            </option>
          ))}
        </select>
      </div>

      <div className="w-72 flex justify-between">
        <label className="text-lg" htmlFor="time">Time</label>
        <input
          type="datetime-local"
          onChange={handleInputChange}
          className="rounded-md bg-gray-100/80 px-2 w-42"
          name="time"
          id="time"
          value={formData.time || ""}
        />
      </div>
      <div className="w-48 p-2">
        <button type="submit"
                className="w-full rounded-md bg-green-500/80 cursor-pointer hover:bg-green-700/80 text-white font-semibold p-1">Submit
        </button>
      </div>

    </form>
  )
};

export default AddAppointment;
