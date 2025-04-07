import React from 'react';
import { Card, CardContent, Typography } from '@mui/material';
import { FileMedtaData } from '../types/PdfMetadata ';
import { styles } from './styles';

type FileDataType = {
    fileMetaData : FileMedtaData
}
const FileData: React.FC<FileDataType> = ({fileMetaData }) => {
    return (
        <Card sx={styles.card}>
        <CardContent>
          <Typography variant="h6">Uploaded File Metadata</Typography>
          <Typography><strong>File Name:</strong> {fileMetaData?.fileName}</Typography>
          <Typography><strong>Title:</strong> {fileMetaData?.title}</Typography>
          <Typography><strong>Author:</strong> {fileMetaData?.author}</Typography>
          <Typography><strong>Page Count:</strong> {fileMetaData?.pageCount}</Typography>
          <Typography><strong>Created Date:</strong> {new Date(fileMetaData?.creationDate)?.toLocaleString()}</Typography>
        </CardContent>
      </Card>
    )

}
export default FileData;
