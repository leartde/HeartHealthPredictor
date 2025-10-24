import axios from "axios";

const DeletePatient = async(id:number)=>{
  const baseUrl = import.meta.env.VITE_API_BASE_URL;
  const url = `${baseUrl}/patients/${id}`;
  try{
    const response = await axios.delete(url);
    if(response.status === 200)return true;
  }
  catch (error){
    console.error("Error deleting patient:", error);
    return false;
  }
}

export default DeletePatient;
