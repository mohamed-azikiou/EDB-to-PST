import pyesedb

esedb_file = pyesedb.file()

esedb_file.open("priv1.edb")
#for column in esedb_file.get_table_by_name("Mailbox").columns:
print([table.get_name()+' # '+str(table.get_number_of_records()) for table in esedb_file.tables])
print([record.get_value_data_as_string(24) for record in esedb_file.get_table_by_name("Mailbox").records])
print([record.get_value_data_as_string(25) for record in esedb_file.get_table_by_name("Mailbox").records])
print([record.get_value_data_as_string(26) for record in esedb_file.get_table_by_name("Mailbox").records])
print([record.get_column_name(4) for record in esedb_file.get_table_by_name("Mailbox").records])
print([record.get_type() for record in esedb_file.get_table_by_name("Mailbox").columns])
#for table in esedb_file.tables:
#    print(table.get_name())
esedb_file.close()