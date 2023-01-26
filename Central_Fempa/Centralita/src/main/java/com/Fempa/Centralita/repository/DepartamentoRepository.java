package com.Fempa.Centralita.repository;
import com.Fempa.Centralita.model.Departamento;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.rest.core.annotation.RepositoryRestResource;

@RepositoryRestResource(collectionResourceRel = "departamento", path = "departamento")
public interface DepartamentoRepository extends JpaRepository<Departamento, Integer> {

}
