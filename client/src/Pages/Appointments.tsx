import React, { useEffect, useState } from 'react';
import type { Appointment } from "../Types/Appointment.ts";
import FetchAllAppointments from "../Services/Appointment/FetchAllAppointments.ts";
import Table from "../Components/Table.tsx";
import { Link } from "react-router";
import DeleteAppointment from "../Services/Appointment/DeleteAppointment.ts";

const Appointments = () => {
  const [appointments, setAppointments] = useState<Appointment[]>([])
  useEffect(() => {
    const getAppointments = async()=>{
       const data = await FetchAllAppointments();
       setAppointments(data);
    }
    getAppointments().then();
  }, []);
  const handleDelete = (id: number) => async() =>{
    const result = await DeleteAppointment(id);
    if(result){
      setAppointments(appointments.filter(app => app.id !== id));
    }
  }
  if(!appointments){
    return <p className="text-green-800 text-lg">No appointments found</p>
  }
  return (
    <>
      <h2 className="text-2xl font-bold text-green-800 mb-4">Appointments</h2>
      <div className="overflow-x-auto rounded-lg text-green-800 mb-4">
        <Table headers={["Id", "Patient Name", "Doctor Name", "Time", ""]}
               rows={appointments.map((app) => ([
                 app.id,
                 `${app.patient.firstName} ${app.patient.lastName}`,
                 `${app.doctor.firstName} ${app.doctor.lastName}`,
                 new Date(app.time).toLocaleTimeString([], {
                   year: 'numeric', month: '2-digit', day: '2-digit',
                   hour: '2-digit', minute: '2-digit'
                 }),
                 <button onClick={handleDelete(app.id)} className="bg-red-600 cursor-pointer hover:bg-red-700 text-white font-bold py-1 px-2 rounded ml-2"> Delete </button>

               ]))}
        />

      </div>
      <div className="p-2 mt-2">
        <Link to="add" className="bg-green-600 hover:bg-green-700 text-white font-bold py-2 px-4 rounded">
          Add new appointment
        </Link>
      </div>
    </>
  );
};

export default Appointments;
