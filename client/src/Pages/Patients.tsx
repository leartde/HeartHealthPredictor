import React, { useEffect, useState } from 'react';
import type { Patient } from "../Types/Patient.ts";
import FetchAllPatients from "../Services/Patient/FetchAllPatients.ts";
import Table from "../Components/Table.tsx";
import { Link } from "react-router";
import DeleteDoctor from "../Services/Doctor/DeleteDoctor.ts";
import DeletePatient from "../Services/Patient/DeletePatient.ts";

const Patients = () => {
  const [patients, setPatients] = useState<Patient[]>([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const getPatients = async () => {
      try {
        const data = await FetchAllPatients();
        setPatients(data);
      } catch (error) {
        console.error("Error fetching patients:", error);
      } finally {
        setLoading(false);
      }
    }
    getPatients().then();
  }, []);

  if (loading) {
    return (
      <div className="flex justify-center items-center h-64">
        <div className="text-green-600 text-lg">Loading patients...</div>
      </div>
    );
  }

  const handleDelete = (id: number) => async () => {
    const result = await DeletePatient(id);
    if (result) {
      setPatients(patients.filter(patient => patient.id !== id));
    }
  }
  return (
    <>
      <h2 className="text-2xl font-bold text-green-800 mb-4">Patient Records</h2>

      <div className="overflow-x-auto rounded-lg shadow-md">
        <Table headers={["Id", "First Name", "Last Name", "Age", "Sex", "Phone Number", "Email", ""]}
               rows={patients.map((patient) => ([
                 patient.id,
                 patient.firstName,
                 patient.lastName,
                 patient.age,
                 patient.sex,
                 patient.phoneNumber,
                 patient.email,
                 <button onClick={handleDelete(patient.id)}
                         className="bg-red-600 cursor-pointer hover:bg-red-700 text-white font-bold py-1 px-2 rounded ml-2"> Delete </button>
               ]))}
        />
      </div>
      <div className="p-2 mt-2">
        <Link to="add" className="bg-green-600 hover:bg-green-700 text-white font-bold py-2 px-4 rounded">
          Add new patient
        </Link>
      </div>
    </>
  );
};

export default Patients;
