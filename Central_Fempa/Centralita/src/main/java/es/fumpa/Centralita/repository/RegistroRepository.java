package es.fumpa.Centralita.repository;

import es.fumpa.Centralita.model.Registro;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.rest.core.annotation.RepositoryRestResource;

@RepositoryRestResource(collectionResourceRel = "registros", path = "registros")
public interface RegistroRepository extends JpaRepository<Registro, Integer> {

}
