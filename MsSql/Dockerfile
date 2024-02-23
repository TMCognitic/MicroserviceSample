FROM mcr.microsoft.com/mssql/server:2022-latest AS sqlserver
ENV ACCEPT_EULA='Y'
ENV MSSQL_SA_PASSWORD='Test1234='
ENV MSSQL_DATA_DIR=/var/opt/mssql/data
ENV MSSQL_PID='Developer' 
ENV MSSQL_TCP_PORT=1433 

EXPOSE 1433

FROM sqlserver
WORKDIR /scripts
COPY /MsSql/scripts .

CMD /opt/mssql-tools/bin/sqlcmd -S localhost,1433 -U SA -P Test1234= -i "/scripts/script.sql" -o "/scripts/out.log"

