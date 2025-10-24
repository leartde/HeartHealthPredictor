import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import './index.css'
import App from './App.tsx'
import { createBrowserRouter, RouterProvider } from "react-router-dom";
import Homepage from "./Pages/Homepage.tsx";
import Doctors from "./Pages/Doctors.tsx";
import Patients from "./Pages/Patients.tsx";
import Appointments from "./Pages/Appointments.tsx";
import ClinicalRecords from "./Pages/ClinicalRecords.tsx";
import ClinicalRecord from "./Pages/ClinicalRecord.tsx";
import AddClinicalRecord from "./Pages/AddClinicalRecord.tsx";
import AddPatient from "./Pages/AddPatient.tsx";
import AddAppointment from "./Pages/AddAppointment.tsx";
import AddDoctor from "./Pages/AddDoctor.tsx";

const router = createBrowserRouter([
  {
    path: "/",
    element: <App />,
    children: [
      {
        index: true,
        element: <Homepage />
      },
      {
        path: "doctors",
        element: <Doctors />
      },
      {
        path: "patients",
        element: <Patients />
      },
      {
        path: "appointments",
        element: <Appointments />
      },
      {
        path: "clinical-records",
        element: <ClinicalRecords />
      },
      {
        path: "clinical-records/:id",
        element: <ClinicalRecord />
      },
      {
        path: "clinical-records/add",
        element: <AddClinicalRecord />
      },
      {
        path: "patients/add",
        element: <AddPatient />
      },
      {
        path: "appointments/add",
        element: <AddAppointment />
      },
      {
        path: "doctors/add",
        element:<AddDoctor/>
      }
    ]
  }
]);

const rootElement = document.getElementById('root');
if (!rootElement) throw new Error('Root element not found');

createRoot(rootElement).render(
  <StrictMode>
    <RouterProvider router={router} />
  </StrictMode>
);
