import axios from "axios";

const CreateDoctor = async(data) => {
  const baseUrl = import.meta.env.VITE_API_BASE_URL;
  const url = `${baseUrl}/doctors`;
  try{
    const response = await axios.post(url, data);
    if(response.status === 200)return true;
  }
  catch (error){
    console.error("Error creating doctor:", error);
    return false;
  }
}

export default CreateDoctor;
