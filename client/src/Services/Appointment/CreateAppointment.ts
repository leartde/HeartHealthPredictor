import axios from "axios";

const CreateAppointment = async(data)=>{
  const baseUrl = import.meta.env.VITE_API_BASE_URL;
  const url = `${baseUrl}/appointments`;
  try{
    const response = await axios.post(url, data);
    if(response.status === 200)return true;
  }
  catch (error){
    console.error("Error adding appointment:", error);
    return false;
  }
}

export default CreateAppointment;
