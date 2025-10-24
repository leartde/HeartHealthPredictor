import axios from "axios";

const DeleteAppointment = async(id: number)=>{
  const baseUrl = import.meta.env.VITE_API_BASE_URL;
  const url = `${baseUrl}/appointments/${id}`;
  try{
    const response = await axios.delete(url)
    if(response.status === 200)return true;
  }
  catch (error){
    console.error("Error deleting appointment:", error);
    return false;
  }
}

export default DeleteAppointment;
