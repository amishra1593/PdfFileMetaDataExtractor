import React, { useState } from 'react';
import {Button,Typography,Box, CircularProgress, Input,} from '@mui/material';
import { uploadPDF } from '../services/PdfService'
import { FileMedtaData } from '../types/PdfMetadata ';
import FileData from './FileData';
import { styles } from './styles';
import { useNavigate } from 'react-router-dom';


// interface Props {
//   onUploadSuccess: () => void;
// }

const FileUpload: React.FC = () => {
  const navigator = useNavigate();
  const [selectedFile, setSelectedFile] = useState<File | null>(null);
  const [fileMetaDataDetails,setFileMetaDataDetails] = useState<FileMedtaData | null>(null);
  const [loading, setLoading] = useState(false);
   const [error, setError] = useState(""); 

  const handleFileChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    const file = event.target.files?.[0];
    if (file && file.type === 'application/pdf') {
      setSelectedFile(file);
    } else {
      setError('Please select a valid PDF file.');
    }
  };

  const handleUpload = async () => {
    if (!selectedFile) return;
    try {
      setError("");
      setLoading(true);
      debugger;
      const response =  await uploadPDF(selectedFile);
      console.log(response.data);
      setFileMetaDataDetails(response.data.fileMetaData)
      setSelectedFile(null);
    } catch (error) {
      setError("Error uploading file. Please try again");
      console.error('Error uploading file:', error);
    }
    finally{
      setLoading(false);
    }
  };

  return (
     <Box sx={styles.container}>
       <Button
            variant="outlined"
            component="span"
            sx={styles.uploadButton}
           onClick={(e) => {navigator("/")}}>View Files</Button>
      <h1>PDF Metadata Extractor</h1>
      <Box sx={styles.uploadBox}>
        <Input
          type="file"
          inputProps={{ accept: 'application/pdf' }}
          onChange={handleFileChange}
          sx={{ display: 'none' }}
          id="pdf-upload"
        />
        <label htmlFor="pdf-upload">
          <Button
            variant="outlined"
            component="span"
            sx={styles.uploadButton}
          >
            Choose PDF
          </Button>
        </label>

        <Typography variant="body2" sx={{ mt: 1 }}>
          {selectedFile?.name || 'No file selected'}
        </Typography>

        <Button
          variant="contained"
          onClick={handleUpload}
          disabled={!selectedFile || loading}
          sx={styles.uploadButton}
        >
          {loading ? <CircularProgress size={24} color="inherit" /> : 'Upload & Extract'}
        </Button>
        {error && <p style={{ color: 'red' }}>{error}</p>} 
      </Box> 
      <Box>
     {fileMetaDataDetails && (
      <FileData fileMetaData={fileMetaDataDetails}></FileData>
      )}
    </Box> 
    </Box> 
  );
};

export default FileUpload;
